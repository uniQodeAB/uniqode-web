using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniQode.Contracts;
using UniQode.Contracts.Services;
using UniQode.Data;
using UniQode.Data.Models;
using UniQode.Data.Repositories;
using UniQode.Entities.Data;
using UniQode.Services;
using UniQode.Services.Cache;

namespace UniQode.Cli
{
    class Program
    {
        private static IAdminRepository<Account> _repository;
        private static IAccountService _accountService;
        private const int CacheTtlInMs = 2000;
        private const char SeperatorChar = '=';
        private static int _previousSeperatorCharLength = 0;

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

        private static int Menu()
        {
            Console.WriteLine(GetSeparator());
            Console.WriteLine("[1] Create user");
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
                    return CreateUser();
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

        private static int CreateUser()
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
                        return Menu();

                    return CreateUser();
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
            return Menu();
        }



        static void Main(string[] args)
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
            
            var context = new AdminModel(nameOrConnectionString);
            _repository = new AdminRepository<Account>(context);
            _accountService = new AccountService(_repository, new DefaultCacheProvider(TimeSpan.FromMilliseconds(CacheTtlInMs)));

            var text = "= Welcome to UniQode CLI! =";

            Console.WriteLine(GetSeparator(text.Length));
            Console.WriteLine(text);

            if (Menu() > 0)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }

    }
}
