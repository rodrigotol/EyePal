using System;
using System.Threading;
using System.Windows;
using RT.EyePal.Infra.CC.Injector.InjectorContainers;
using RT.EyePal.Wpf.Forms;
using SimpleInjector;

namespace RT.EyePal.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    ///// </summary>
    public class App : System.Windows.Application
    {
        private static readonly Mutex Mutex = new Mutex(true, "{3C91215F-31CF-494F-A813-9A0300521980}");
        private static MainWindow _mainWindow = null;

        [STAThread]
        static void Main()
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                var container = Bootstrap();

                App app = new App {ShutdownMode = ShutdownMode.OnMainWindowClose};

                _mainWindow = container.GetInstance<MainWindow>();
                app.MainWindow = _mainWindow;

                app.Run(_mainWindow);
                Mutex.ReleaseMutex();
            }
        }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:
            container.Register<MainWindow>();

            ApplicationInjectorContainer.Register(container);
            InfraInjectionContainer.Register(container);

            return container;
        }
    }
}
