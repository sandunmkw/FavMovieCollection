using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Core.Contracts;
using Core.BusinessObjects;
using Core.DataAccessObjects;
using WebApplication.Unity;

namespace WebApplication.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<IDirectorBo, DirectorBo>(new HierarchicalLifetimeManager());
            container.RegisterType<IDirectorDao, DirectorDao>(new HierarchicalLifetimeManager());

            container.RegisterType<ILanguageBo, LanguageBo>(new HierarchicalLifetimeManager());
            container.RegisterType<ILanguageDao, LanguageDao>(new HierarchicalLifetimeManager());

            container.RegisterType<IFilmBo, FilmBo>(new HierarchicalLifetimeManager());
            container.RegisterType<IFilmDao, FilmDao>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            var formatter = config.Formatters;
            var jsonFormatter = formatter.JsonFormatter;
            var setting = jsonFormatter.SerializerSettings;
            setting.Formatting = Formatting.Indented;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}