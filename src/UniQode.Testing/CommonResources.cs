using System;
using System.IO;

namespace UniQode.Testing
{
    public class CommonResources
    {
        public static class ConnectionStrings
        {
            private const string EnvironmentVariableAzureServiceBus = "UNIQODEWEB_TESTS_ASB_CONNECTION_STRING";
            private const string EnvironmentVariableAzureBlobStorage = "UNIQODEWEB_TESTS_ABS_CONNECTION_STRING";

            private const string FilenameVariableAzureServiceBus = @"C:\Temp\UniQodeWebConnectionString.txt";
            private const string FilenameVariableAzureBlobStorage = @"C:\Temp\UniQodeWebBlobStorageConnectionString.txt";

            /// <summary>
            ///     The connection string for Azure Service Bus (loaded from either environment varibles or file on disk)
            /// </summary>
            public static string AzureServiceBus { get; set; } = InitConnectionString(EnvironmentVariableAzureServiceBus, FilenameVariableAzureServiceBus);

            /// <summary>
            ///     The connection string for Azure Blob Storage (loaded from either environment varibles or file on disk)
            /// </summary>
            public static string AzureBlobStorage { get; set; } = InitConnectionString(EnvironmentVariableAzureBlobStorage, FilenameVariableAzureBlobStorage);

            private static string InitConnectionString(string envVariable, string filename)
            {
                var connectionString = Environment.GetEnvironmentVariable(envVariable);
                if (string.IsNullOrEmpty(connectionString))
                    if (File.Exists(filename))
                        connectionString = File.ReadAllText(filename).Trim();

                if (string.IsNullOrEmpty(connectionString))
                    throw new Exception(
                        $"Could not find either the environment variable with name {envVariable}, nor file {filename} containing the Azure Service Bus connection string to use for integration testing");

                return connectionString;
            }
        }
    }
}