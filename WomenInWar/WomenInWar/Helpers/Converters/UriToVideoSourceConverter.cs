using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;

namespace WomenInWar.Helpers.Converters
{
    public class UriToVideoSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string uriString)
            {
                Uri uri = new Uri(uriString, UriKind.RelativeOrAbsolute);
                if (!uri.IsAbsoluteUri)
                    uri = new Uri("ms-appx:///" + uriString);
                return MediaSource.CreateFromUri(uri);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
