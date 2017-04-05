using Windows.ApplicationModel.Resources;

namespace BlameGame
{
    static class AssetAssigner
    {
        private static string _imageDir;
        private static ResourceLoader _resourceFile;

        // property for the directory that holds images
        public static string ImageDir
        {
            get
            {
                _imageDir = AssignImageDir(CaseIdStatic.CaseId);
                return _imageDir;
            }
        }

        // property for the resource files that holds game strings
        public static ResourceLoader ResourceFile
        {
            get
            {
                _resourceFile = AssignResourceFile(CaseIdStatic.CaseId);
                return _resourceFile;
            }
        }


        /// <summary>
        /// Methods set working image and resource directory to get image files and strings, based on CaseIdStatic.cs, to build suspects and case later 
        /// </summary>
        // Done: Merge into a single class which will construct Images & Strings simultaniously

        private static string AssignImageDir(int id)
        {
            var dir = string.Empty;
            switch (id)
            {
                case 1:
                    dir = @"Assets\humans";
                    break;
                case 2:
                    dir = @"Assets\dogs";
                    break;
                case 3:
                    dir = @"Assets\normal_people";
                    break;
                default:
                    dir = @"Assets\dogs";
                    break;
            }
            return dir;
        }

        private static ResourceLoader AssignResourceFile(int caseId)
        {
            ResourceLoader resFile = null;
            switch (caseId)
            {
                case 1:
                    resFile = ResourceLoader.GetForCurrentView("StringsOfficeIncident");
                    break;
                case 2:
                    resFile = ResourceLoader.GetForCurrentView("StringsDogs");
                    break;
                case 3:
                    resFile = ResourceLoader.GetForCurrentView("StringsBlackmail");
                    break;
                default:
                    resFile = ResourceLoader.GetForCurrentView("StringsDogs");
                    break;
            }
            return resFile;
        }
    }
}
