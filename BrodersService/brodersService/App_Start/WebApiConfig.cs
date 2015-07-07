using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using brodersService.DataObjects;
using brodersService.Models;

namespace brodersService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new brodersInitializer());
        }
    }

    public class brodersInitializer : ClearDatabaseSchemaIfModelChanges<brodersContext>
    {
        protected override void Seed(brodersContext context)
        {
            List<PropertyInfo> propertyItems = new List<PropertyInfo>
            {
                new PropertyInfo 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Amount  = 1300000, 
                    City= "Johannesburg" , 
                    Province = "Gauteng", 
                   
                    Street = "6 Main Road", 
                    Suburb = "Midrand",
                    Url = "www.privateproperty.co.za"
                    

                }
                
            };

            foreach (PropertyInfo propertyItem in propertyItems)
            {
                context.Set<PropertyInfo>().Add(propertyItem);
            }

            base.Seed(context);
        }
    }
}

