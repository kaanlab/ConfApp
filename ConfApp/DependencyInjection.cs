using ConfApp.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbStorage(this IServiceCollection services)
        {
            services.AddDbContext<StorageService>();
            services.AddScoped<IStorageService, StorageService>();

            services.AddTransient<IConferenceService, ConferenceService>();
            services.AddTransient<IInstitutionService, InstitutionService>();
            services.AddTransient<ISpeakerService, SpeakerService>();
            services.AddTransient<IReportService, ReportService>();

            return services;
        }

        public static IServiceCollection AddFileStorage(this IServiceCollection services)
        {
            services.AddTransient<IFileStorageService, FileStorageService>();

            return services;
        }
    }
}
