using Microsoft.EntityFrameworkCore;
using CRUDAtEmailAddress.Repositories;

namespace CRUDAtEmailAddress
{
    public static class Startup
    {

        public static IServiceCollection AddModule(this IServiceCollection services, string? connectionString)
        {
            //على كيفي
            services.AddScoped<IContactTypeRepository , ContactTypesRepository>();

            services.AddDbContext<AdventureWorks2022Context>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }

    }
}
