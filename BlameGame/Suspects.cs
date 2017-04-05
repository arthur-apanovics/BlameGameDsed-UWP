using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Media.Imaging;

namespace BlameGame
{
    class Suspects
    {
        /// <summary>
        /// This class is used to construct suspects on the game page.
        /// </summary>

        //suspect list property, used to populate GamePage using Data Binding
        public ObservableCollection<SuspectModel> SuspectList { get; set; }

        public Suspects()
        {
            SuspectList = new ObservableCollection<SuspectModel>();
            //get a random number that will be used for creating a guilty suspect
            int guiltyId = GuiltRandomizer();

            //get image set depending on case
            CaseImageRetriever getImages = new CaseImageRetriever();
            var images = getImages.Images;

            //get the resource file to retrieve strings
            var resFile = AssetAssigner.ResourceFile;

            //get a randomized array of answers
            var rndAnswr = AnswerRandomizer(resFile);

            //create suspects based on the SuspectModel and assign one suspect the guilt status
            SuspectList = PopulateSuspects(guiltyId, images, resFile, rndAnswr);
        }

        // Method used to create the list that holds suspects which are used on the main game page
        private ObservableCollection<SuspectModel> PopulateSuspects(int guiltyId, BitmapImage[] images, ResourceLoader resFile, string[,] rndAnswr)
        {
            var suspList = new ObservableCollection<SuspectModel>();
            //this int is used to index into the rndAnswr array since it only holds 5 items per dimension
            int j = 0;

            for (int i = 0; i < 6; i++)
            {
                if (i == guiltyId)
                {
                    //create a guilty suspect based on SuspectModel. Populate with questions directly from resource file.
                    suspList.Add(new SuspectModel
                        (images[guiltyId], resFile.GetString($"gA0Q1"), resFile.GetString($"gA0Q2"), guiltyId + 1, true));
                }
                else
                {
                    //create an innocent suspect based on SuspectModel. Populate with questions from rndAnswr array.
                    suspList.Add(new SuspectModel
                        (images[i], rndAnswr[0, j], rndAnswr[1, j], i + 1, false));
                    //increment int j to use with rndAnswr array on the next loop
                    j++;
                }
            }

            return suspList;
        }

        //suspect "guilt" randomizer. Used in the constructor
        private int GuiltRandomizer()
        {
            int randomGuilt;
            Random rnd = new Random();
            //get random number from 0-5 since array is zero based
            randomGuilt = rnd.Next(0, 6);

            return randomGuilt;
        }

        //returns a shuffled string array that holds answers for innocent suspects
        private string[,] AnswerRandomizer(ResourceLoader resource)
        {
            //setup
            Random rnd = new Random();
            string[,] answers = new string[2,5];
            
            //create two-dimensional array that holds 2*5 strings
            int[] rndNumArr = { 0, 1, 2, 3, 4 };
            //shuffle numbers in array
            rndNumArr = rndNumArr.OrderBy(x => rnd.Next()).ToArray();

            //populate array with answers
            for (int i = 0; i < rndNumArr.Length; i++)
            {
                //populate array with Q1 answers
                answers[0,i] = resource.GetString($"iA{rndNumArr[i]}Q1");
                //populate array with Q2 answers
                answers[1, i] = resource.GetString($"iA{rndNumArr[i]}Q2");
            }

            return answers;
        }
    }
}
