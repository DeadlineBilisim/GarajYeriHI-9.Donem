using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Business.Concrete;
using GarajYeriHI.Repository.Shared.Abstract;
using GarajYeriHI.Repository.Shared.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Business
{
    public static class BusinessExtension
    {

        //butun servisleri buraya her seferinde tekrar tekrar yazmamak için kullanılan dinamik çalışan hazır metot örneği 

        public static void AddBusinessDI_Dinamik(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes()
                                .Where(t => t.Namespace != null && t.Namespace.StartsWith("CraneERP.Business.Concrate") &&
                                            !t.Name.Contains('<') && !t.Name.Contains(">") && !t.Name.Contains("__"))
                                .ToArray();

            // Servisleri tarayın ve uygun olanları ekleyin
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    if (@interface.Name == $"I{type.Name}") // Interface'in sınıfın ismiyle uyumlu olup olmadığını kontrol edin
                    {
                        services.AddScoped(@interface, type);
                    }
                }
            }
        }


        public static void AddBusinessDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPolicyTypeService, PolicyTypeService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<IPolicyService, PolicyService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehiclePhotoService, VehiclePhotoService>();
            services.AddScoped<IVehicleService, VehicleService>();

        }
    }
}
