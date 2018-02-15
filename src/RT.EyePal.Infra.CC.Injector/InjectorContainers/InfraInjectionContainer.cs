using RT.EyePal.Domain.Interfaces.Respositories;
using RT.EyePal.Infra.Data.Context;
using RT.EyePal.Infra.Data.Interfaces.Context;
using RT.EyePal.Infra.Data.Repositories;
using SimpleInjector;

namespace RT.EyePal.Infra.CC.Injector.InjectorContainers
{
    public class InfraInjectionContainer
    {
        public static void Register(Container container)
        {
            container.Register<IConfigurationContext, ConfigurationContext>();

            container.Register(typeof(IXmlRepository<>), new[] { typeof(IXmlRepository<>).Assembly });
            container.Register<IFilterConfigurationRepository, FilterConfigurationRepository>();
        }
    }
}