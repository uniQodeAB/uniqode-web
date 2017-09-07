using Autofac;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Streamstone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UniQode.Contracts.Services;
using UniQode.Data.Models;
using UniQode.Data.Repositories;
using UniQode.Entities.Data;
using UniQode.Services;
using UniQode.Services.Providers;
using UniQode.Testing;

namespace UniQode.Cli
{
    class Program
    {
        private static IAccountService _accountService;
        private static CrudService<Employee, Guid> _employeeService;
        private static CrudService<Motto, Guid> _mottoService;
        private static CrudService<WorkField, Guid> _workfieldService;
        private static CrudService<NewsArticle, long> _newsService;
        private const int CacheTtlInMs = 2000;
        private const char SeperatorChar = '=';
        private static int _previousSeperatorCharLength = 0;
        private static Partition _partion;

        private static string GetSeparator(int length = 0)
        {
            if (length == 0)
                length = _previousSeperatorCharLength;

            _previousSeperatorCharLength = length;

            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                builder.Append(SeperatorChar);
            }
            return builder.ToString();
        }

        private static async Task<int> Menu()
        {
            Console.WriteLine(GetSeparator());
            Console.WriteLine("[1] Create user");
            Console.WriteLine("[2] Move data from SQL to Azure Table");
            Console.WriteLine("[0] Exit");
            Console.WriteLine();
            Console.Write("Choose wisely: ");

            var action = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            switch (action.KeyChar)
            {
                case '0':
                    return 0;
                case '1':
                    return await CreateUser();
                case '2':
                    return await MigrateDatabase();
                default:
                    Console.WriteLine("Unknown command!");
                    return 1;

            }
        }

        private static int GoBack()
        {
            Console.WriteLine("Go back?");
            Console.Write("Proceed (y/n): ");
            var action = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            switch (action.KeyChar)
            {
                case 'n':
                    return 0;
                default:
                    return 1;

            }
        }

        private static async Task<int> CreateUser()
        {
            var text = "= Create admin user =";
            Console.WriteLine(GetSeparator(text.Length));
            Console.WriteLine(text);
            Console.WriteLine(GetSeparator(text.Length));
            
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Do you want to create the following user?");
            Console.WriteLine("\tName: {0}", name);
            Console.WriteLine("\tEmail: {0}", email);
            Console.WriteLine("\tPassword: {0}", password);
            Console.WriteLine();
            Console.Write("Proceed (y/n): ");
            var action = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            switch (action.KeyChar)
            {
                case 'y':
                    break;
                case 'n':
                    if (GoBack() > 0)
                        return await Menu();

                    return await CreateUser();
                default:
                    Console.WriteLine("Unknown command!");
                    return 1;

            }
            
            try
            {
                var account = _accountService.Create(name, email, password);
                Console.WriteLine("User created with id: {0}", account.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("User creation failed! {0}", ex.Message);
            }

            Console.WriteLine();
            return await Menu();
        }

        private static async Task<int> MigrateDatabase()
        {
            var text = "= Move data from SQL to Azure Table =";
            Console.WriteLine(GetSeparator(text.Length));
            Console.WriteLine(text);
            Console.WriteLine(GetSeparator(text.Length));
            Console.WriteLine();
            
            var dbModel = new UniQodeDatabase
            {
                Employees = _employeeService.List(),
                Mottos = _mottoService.List(),
                News = _newsService.List(),
                Workfields = _workfieldService.List()
            };

            var json = JsonConvert.SerializeObject(dbModel,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            using (var fs = File.Create(@"c:\temp\uniqode-db.json"))
            using(var writer = new StreamWriter(fs))
            {
                writer.Write(json);
            }
            
            var existent = await Streamstone.Stream.TryOpenAsync(_partion);

            var stream = existent.Found
                ? existent.Stream
                : new Streamstone.Stream(_partion);

            Console.WriteLine("Writing to new stream in partition '{0}'", stream.Partition);

            var id = Guid.NewGuid();
            var properties = new
            {
                Type = "Initial",
                Data = json
            };

            var evt = new EventData(EventId.From(id), EventProperties.From(properties));

            var result = await Streamstone.Stream.WriteAsync(stream, evt);

            Console.WriteLine("Succesfully written to new stream.\r\nEtag: {0}, Version: {1}",
                              result.Stream.ETag, result.Stream.Version);

            //Console.WriteLine(json);

            Console.Write("Go back (y): ");
            var action = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            return await Menu();

        }

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var nameOrConnectionString = "name=DbContext";
            for (var i = 0; i < args.Length; i++)
            {
                var valueIndex = i + 1;
                if (args.Length > valueIndex && (args[i].Equals("-ConnectionString") || args[i].Equals("-connectionString") || args[i].Equals("-connectionstring")))
                {
                    nameOrConnectionString = args[valueIndex];
                    break;
                }
            }
            var cacheProvider = new DefaultCacheProvider(TimeSpan.FromMilliseconds(CacheTtlInMs));
            var adminContext = new AdminModel(nameOrConnectionString);
            var primaryContext = new PrimaryModel(nameOrConnectionString);
            
            _accountService = new AccountService(new AdminRepository<Account>(adminContext), cacheProvider);
            _employeeService = new CrudService<Employee, Guid>(new PrimaryRepository<Employee>(primaryContext), cacheProvider);
            _mottoService = new CrudService<Motto, Guid>(new PrimaryRepository<Motto>(primaryContext), cacheProvider);
            _workfieldService = new CrudService<WorkField, Guid>(new PrimaryRepository<WorkField>(primaryContext), cacheProvider);
            _newsService = new CrudService<NewsArticle, long>(new PrimaryRepository<NewsArticle>(primaryContext), cacheProvider);
            
            var table = await Prepare(CommonResources.ConnectionStrings.AzureBlobStorage);
            var id = "Regular";
            _partion = new Partition(table, id);

            var text = "= Welcome to UniQode CLI! =";

            Console.WriteLine(GetSeparator(text.Length));
            Console.WriteLine(text);

            if (await Menu() > 0)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }

        static async Task<CloudTable> Prepare(string connectionString)
        {
            var table = CloudStorageAccount.Parse(connectionString)
                .CreateCloudTableClient()
                .GetTableReference("States");

            //await table.DeleteIfExistsAsync();
            await table.CreateIfNotExistsAsync();

            return table;
        }

        public class UniQodeDatabase
        {
            public ICollection<Motto> Mottos { get; set; }

            public ICollection<WorkField> Workfields { get; set; }

            public ICollection<Employee> Employees { get; set; }

            public ICollection<NewsArticle> News { get; set; }
        }
    }
}
