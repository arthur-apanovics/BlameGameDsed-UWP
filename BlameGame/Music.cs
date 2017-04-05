using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace BlameGame
{
    static class Music
    {

        /// <summary>
        /// This class plays and stops music files
        /// </summary>
        
        public static async void StartMusic()
        {
            var soundFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/loop.wav"));
            await PlayAudioAsync(soundFile);
        }

        public static async void StopMusic()
        {
            
        }
        
        public static async Task PlayAudioAsync(IStorageFile mediaFile, bool looping = true)
        {
            var stream = await mediaFile.OpenAsync(FileAccessMode.Read).AsTask();
            var mediaControl = new MediaElement() { IsLooping = looping };
            mediaControl.SetSource(stream, mediaFile.ContentType);
            mediaControl.Play();
        }
    }
}
