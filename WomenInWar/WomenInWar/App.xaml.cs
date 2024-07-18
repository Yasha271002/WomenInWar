using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Windowing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
using Windows.Graphics.Display;
using WomenInWar.Helpers;
using WomenInWar.View.Windows;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WomenInWar
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            MainWindow = new MainWindow();
            MainWindow.Activate();

            VideoWindow = new VideoWindow();
            VideoWindow.Activate();

            var monitors = MonitorHelper.All.ToArray();
            if (monitors.Length > 1)
            {
                var thisMonitor = MonitorHelper.FromWindow(WinRT.Interop.WindowNative.GetWindowHandle(MainWindow));
                var otherMonitor = monitors.First(m => m.DeviceName != thisMonitor.DeviceName);
                VideoWindow.AppWindow.Move(new PointInt32(otherMonitor.WorkingArea.X, otherMonitor.WorkingArea.Y));
            }

            SetFullscreen(MainWindow);
            SetFullscreen(VideoWindow);
        }

        public static Window MainWindow { get; set; }
        public static Window VideoWindow { get; set; }

        private AppWindow GetAppWindowForCurrentWindow(Window window)
        {
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            var myWndId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(myWndId);
        }

        private void SetFullscreen(Window window)
        {
            var appWindow = GetAppWindowForCurrentWindow(window);
            appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
        }
    }
}
