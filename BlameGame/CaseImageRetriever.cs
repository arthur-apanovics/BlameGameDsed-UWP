using System;
using System.IO;
using System.Linq;
using Windows.UI.Xaml.Media.Imaging;

namespace BlameGame
{
    class CaseImageRetriever
    {
        /// <summary>
        /// This class assigns and holds images that are assigned to suspects
        /// </summary>
        /// 
        //Image property to fetch image set
        private BitmapImage[] _images;

        public BitmapImage[] Images
        {
            get
            {
                var imgDir = AssetAssigner.ImageDir;
                var filePaths = GetRandomImagePaths(imgDir);
                _images = AssignPathToImage(filePaths);
                return _images;
            }
        }

        /// <summary>
        /// This section gets random images from the Assets folder and stores them in Bitmap array.
        /// </summary>
        public string[] GetRandomImagePaths(string directory)
        {
            //this code "borrowed" from stackowerflow. Grab 6 randomly ordered files from specified directory
            var rnd = new System.Random();
            var files = Directory.GetFiles(directory, "*.png")
                                 .OrderBy(x => rnd.Next())
                                 .Take(6)
                                 .ToArray();
            return files;
        }

        private BitmapImage[] AssignPathToImage(string[] files)
        {
            BitmapImage[] imgFiles = new BitmapImage[6];

            //image.Source uses Uri for image paths, so this crap is needed
            for (int i = 0; i < 6; i++)
            {
                //Convert file paths to Uri paths and store in array
                files[i] = Directory.GetCurrentDirectory() + "\\" + files[i];
                Uri uri = new Uri(files[i], UriKind.Relative);
                imgFiles[i] = new BitmapImage(uri);
            }

            return imgFiles;
        }
    }
}
