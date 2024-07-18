using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using WomenInWar.Helpers;
using WomenInWar.Helpers.Logging;
using WomenInWar.Utilities;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WomenInWar.View.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window,INotifyPropertyChanged
    {
        public MainWindow()
        {
            this.InitializeComponent();
            _inactivity.OnInactivity += InactivityOnInactivity;
            Logger.Add(new FileLoggingService("logs"));
            ContentLoader.LoadCharacters();
            NavigationManager.Instance.MainFrame = MainFrame;
            CommonCommands.NavigateCommand.Execute(PageTypes.MainMenuPage);
        }

        private BaseInactivityHelper _inactivity = new(10);
        DispatcherTimer _timer = new ();
        private int _sec = 0;

        private void InactivityOnInactivity(int inactivitytime)
        {
            if (inactivitytime != 0) 
                CommonCommands.NavigateCommand.Execute(PageTypes.InactivityPage);
        }

        private ICommand _startTimer;
        public ICommand StartTimer => (_startTimer ?? new RelayCommand(f =>
        {
            _timer?.Stop();
            _sec = 0;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer;
            _timer.Start();
        }));

        private void Timer(object sender, object e)
        {
            _sec++;
            if (_sec >= 7)
            {
                Application.Current.Exit();
            }
        }

        private ICommand _stopTimer;
        public ICommand StopTimer => (_stopTimer ?? new RelayCommand(f =>
        {
            _timer.Tick -= Timer;
            _timer.Stop();
            _sec = 0;
        }));

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
