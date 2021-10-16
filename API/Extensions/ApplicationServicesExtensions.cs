using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Scoped objects are the same within a request, but different across different requests.
            //Transient objects are always different; a new instance is provided to every controller and every service.
            // Singleton objects are the same for every object and every request.
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                  {
                      var errors = actionContext.ModelState
                      .Where(e => e.Value.Errors.Count > 0)
                      .SelectMany(x => x.Value.Errors)
                      .Select(x => x.ErrorMessage).ToArray();

                      var errorResponse = new ApiValidationErrorResponse
                      {
                          Errors = errors
                      };

                      return new BadRequestObjectResult(errorResponse);
                  };
            });
            return services;
        }
    }
}