using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace WomenInWar.Helpers.Behaviors
{
    public class LoopMediaBehavior : Behavior<MediaPlayerElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject != null)
            {
                AssociatedObject.Loaded += AssociatedObject_Loaded;
                AssociatedObject.Unloaded += AssociatedObject_Unloaded;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.Loaded -= AssociatedObject_Loaded;
                AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
                if (AssociatedObject.MediaPlayer != null)
                {
                    AssociatedObject.MediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
                }
            }
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.MediaPlayer != null)
            {
                AssociatedObject.MediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            }
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.MediaPlayer != null)
            {
                AssociatedObject.MediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
            }
        }

        private void MediaPlayer_MediaEnded(MediaPlayer sender, object args)
        {
            sender.Play();
        }
    }
}
