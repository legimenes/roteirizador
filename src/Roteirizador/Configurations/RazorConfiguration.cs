using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Roteirizador.Configurations
{
    public static class RazorConfiguration
    {
        public static IServiceCollection AddRazorConfig(this IServiceCollection services)
        {
            services.AddRazorPages();

            return services;
        }

        public static IApplicationBuilder UseRazorConfig(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            return app;
        }
    }
}