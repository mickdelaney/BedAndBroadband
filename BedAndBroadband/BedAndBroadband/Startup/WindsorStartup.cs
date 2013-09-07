using System.Collections.Generic;
using BedAndBroadband.Api;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Simple.Web.Windsor;

namespace BedAndBroadband.Startup
{
    using Data;

    public class WindsorStartup : WindsorStartupBase
    {
        protected override IEnumerable<IWindsorInstaller> GetInstallers()
        {
            yield return new BedAndBroadbandInstaller();
        }

        public class BedAndBroadbandInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component.For<IHotels>().ImplementedBy<Hotels>().LifestyleScoped());
                container.Register(Component.For<GetHotel>());
                container.Register(Component.For<AddRating>());
                container.Register(Component.For<GetRecentlyRatedHotels>());
            }
        }
    }
}