using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using RT.EyePal.Services;

namespace RT.EyePal.Wpf.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        private readonly Action _closingEventCallback;
        public FilterWindow(Action closingEventCallBack)
        {
            InitializeComponent();

            _closingEventCallback = closingEventCallBack;

            this.Closing += FilterWindow_Closing;
            this.ShowInTaskbar = false;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowServices.SetWindowExTransparent(hwnd);
        }

        private void FilterWindow_Closing(object sender, CancelEventArgs e)
        {
            _closingEventCallback();
        }
    }
}
