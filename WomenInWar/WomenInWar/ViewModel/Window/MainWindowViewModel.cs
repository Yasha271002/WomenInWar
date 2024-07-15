using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ABI.Microsoft.UI.Xaml.Controls;
using Core;
using Newtonsoft.Json;
using WomenInWar.Helpers;
using WomenInWar.View.Pages;

namespace WomenInWar.ViewModel.Window
{
    public class MainWindowViewModel:ObservableObject
    {
        private BaseInactivityHelper _inactivity = new BaseInactivityHelper(180);

        public MainWindowViewModel()
        {
            _inactivity.OnInactivity += InactivityOnOnInactivity;
           
        }

        private void InactivityOnOnInactivity(int inactivitytime)
        {
        }
    }
}
