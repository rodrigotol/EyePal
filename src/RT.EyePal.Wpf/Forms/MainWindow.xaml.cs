using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using RT.EyePal.Application.Interfaces.Apps;
using RT.EyePal.Application.ViewModels;
using RT.EyePal.Infra.CC;
using ImageService = RT.EyePal.Wpf.Helpers.ImageService;

namespace RT.EyePal.Wpf.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMainWindowApp _mainWindowApp;
        private FilterConfigurationViewModel _filterConfiguration;

        private ColorDialog _colorPicker;
        private NotifyIcon _notifyIcon;        
        private FilterWindow _filterWindow;        
        
        public MainWindow(IMainWindowApp mainWindowApp)
        {
            _mainWindowApp = mainWindowApp;

            InitializeComponent();
            ToggleFilterWindowState(false);

            CustomInitializeComponents();
            CreateEvents();            
        }



        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _mainWindowApp.SaveFilterConfiguration(_filterConfiguration);
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            var me = (MouseEventArgs) e;

            if (me.Button == MouseButtons.Left)
            {
                this.Show();
                _notifyIcon.Visible = false;
            }else if (me.Button == MouseButtons.Right)
            {
                ToggleFilterWindowState();
            }
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            _notifyIcon.Visible = true;
            this.Hide();
        }

        private void SdrFilterOpacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _filterConfiguration.FilterOpacity = (this.SdrFilterOpacity.Value / SdrFilterOpacity.Maximum);

            _filterWindow.Background = GenerateColorBrush();
        }

        private void BtnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            _colorPicker.Color = _filterConfiguration.FilterColor;

            _colorPicker.ShowDialog();

            _filterConfiguration.FilterColor = _colorPicker.Color;

          
           _filterWindow.Background = GenerateColorBrush();            
        }

        private void BtnToggleFilter_Click(object sender, RoutedEventArgs e)
        {
            ToggleFilterWindowState();
        }

        


        private SolidColorBrush GenerateColorBrush()
        {
            var wpfColor = new Color
            {
                A = _filterConfiguration.GetFilterOpacityAsByte(),
                R = _filterConfiguration.FilterColor.R,
                G = _filterConfiguration.FilterColor.G,
                B = _filterConfiguration.FilterColor.B
            };

            return new SolidColorBrush(wpfColor);
        }

        private void CreateNewFilterWindow()
        {
            _filterWindow = new FilterWindow(FilterWindow_ClosingCallback);                       
        }

        private void FilterWindow_ClosingCallback()
        {
            _filterWindow = null;
            this.Owner = null;
        }

        private void ToggleFilterWindowState(bool? forceState = null)
        {
            if(_filterWindow == null)
                CreateNewFilterWindow();

            if (_filterWindow.IsVisible || forceState == false)
            {
                _filterWindow.Hide();

                this.BtnToggleFilter.Content = EyepalResource.TurnOn;
            }
            else if(!_filterWindow.IsVisible || forceState == true)
            {
                _filterWindow.Show();

                this.Owner = _filterWindow;
                this.BtnToggleFilter.Content = EyepalResource.TurnOff;
                this.Focus();
            }
        }

        private void CreateEvents()
        {
            _notifyIcon.Click += NotifyIcon_Click;
            BtnToggleFilter.Click += BtnToggleFilter_Click;
            BtnChangeColor.Click += BtnChangeColor_Click;
            BtnHide.Click += BtnHide_Click;
            BtnQuit.Click += BtnQuit_Click;
            SdrFilterOpacity.ValueChanged += SdrFilterOpacity_ValueChanged;
            this.Closing += MainWindow_Closing;
        }

        private void CustomInitializeComponents()
        {
            _filterConfiguration = _mainWindowApp.LoadFilterConfiguration() ?? _mainWindowApp.GetViewModel();

            this.Icon = ImageService.GenerateImageSource(EyepalResource.eyepalimg);
            this.BtnChangeColor.Content = EyepalResource.ChangeColor;
            this.BtnHide.ToolTip = EyepalResource.Hide;
            this.BtnQuit.Content = EyepalResource.Quit;

            _colorPicker = new ColorDialog();
            _notifyIcon = new NotifyIcon()
            {
                Visible = false,
                Icon = EyepalResource.eyepalicon,
                Text = EyepalResource.EyePal
            };

            this.SdrFilterOpacity.Maximum = 100;
            this.SdrFilterOpacity.Value = _filterConfiguration.FilterOpacity * this.SdrFilterOpacity.Maximum;

            _filterWindow.Background = GenerateColorBrush();
        }
    }
}
