using RT.EyePal.Application.Apps;
using RT.EyePal.Application.Interfaces.Apps;
using SimpleInjector;

namespace RT.EyePal.Infra.CC.Injector.InjectorContainers
{
    public class ApplicationInjectorContainer
    {
        public static void Register(Container container)
        {
            container.Register<IMainWindowApp, MainWindowApp>();
        }
    }
}