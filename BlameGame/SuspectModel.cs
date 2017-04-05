using Windows.UI.Xaml.Media.Imaging;

namespace BlameGame
{

    /// <summary>
    /// This class holds the object model for a suspect.
    /// </summary>
    
    class SuspectModel
    {
        // Properties are not named according to standards. Too late to change, don't want to break anything.

        public BitmapImage suspectImage { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public int suspectId { get; set; }
        public bool isGuilty { get; set; }


        public SuspectModel(BitmapImage image, string answ1, string answ2, int id, bool guilty)
        {
            suspectImage = image;
            Answer1 = answ1;
            Answer2 = answ2;
            isGuilty = guilty;
            suspectId = id;
        }

    }
}
