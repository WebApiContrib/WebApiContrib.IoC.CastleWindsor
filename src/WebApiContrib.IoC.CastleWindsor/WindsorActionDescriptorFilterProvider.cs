namespace WebApiContrib.IoC.CastleWindsor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Castle.Windsor;

    public class WindsorActionDescriptorFilterProvider : ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly IWindsorContainer container;

        public WindsorActionDescriptorFilterProvider(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);

            return filters.Select(filter => this.container.BuildUp(filter));
        }
    }
}