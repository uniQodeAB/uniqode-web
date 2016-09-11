using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace UniQode.Data
{
    public class AzureDbConfiguration : DbConfiguration
    {
        public AzureDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(3, TimeSpan.FromSeconds(30)));
            //SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}