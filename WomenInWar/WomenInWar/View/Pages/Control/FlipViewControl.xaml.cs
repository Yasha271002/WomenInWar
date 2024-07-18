using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WomenInWar.View.Pages.Control
{
    public sealed partial class FlipViewControl : UserControl
    {
        public FlipViewControl()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(FlipViewControl), new PropertyMetadata(null));

        public object ItemsSource
        {
            get { return (object)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(FlipViewControl), new PropertyMetadata(null));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlipView.SelectedIndex > 0)
            {
                FlipView.SelectedIndex--;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlipView.SelectedIndex < FlipView.Items.Count - 1)
            {
                FlipView.SelectedIndex++;
            }
        }
    }
}
