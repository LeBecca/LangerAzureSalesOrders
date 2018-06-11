namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLangerSalesOrderDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<LangerSalesOrders.Data.Database.Database>(sp =>
            {
                return new LangerSalesOrders.Data.Database.Database(connectionString, System.Data.SqlClient.SqlClientFactory.Instance);
            });

            services.AddScoped<LangerSalesOrders.Data.Database.DbScope>(sp =>
            {
                return sp.GetService<LangerSalesOrders.Data.Database.Database>().Begin();
            });

            // data repositories
            services.AddTransient<LangerSalesOrders.Data.Repositories.ISalesOrderRepository, LangerSalesOrders.Data.Repositories.SalesOrderRepository>();
        }
    }
}