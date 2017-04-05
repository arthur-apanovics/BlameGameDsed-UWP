using Windows.ApplicationModel.Resources;

namespace BlameGame
{
    class CaseConstructor
    {
        /// <summary>
        /// This class is used for new case creation upon loading of GamePage.xaml 
        /// </summary>
        /// 
        // property has to be instatntiated before it can be used
        public CaseModel CaseStrings { get; set; } = new CaseModel("Def_Title", "Def_Content", "Def_Question 1", "Def_Question 2"); //set default string for testing

        public ResourceLoader CaseResFile { get; set; }

        public string ResourceImages { get; set; }

        public CaseConstructor()
        {
            // set necessary variables
            CaseResFile = AssetAssigner.ResourceFile;
            SetCaseStrings(CaseStrings);
        }

        // set strings for the current case
        private void SetCaseStrings(CaseModel thisCase)
        {
            thisCase.CaseTitle = CaseResFile.GetString("title");
            thisCase.CaseContent = CaseResFile.GetString("content");
            thisCase.CaseQuestionOne = CaseResFile.GetString("q1");
            thisCase.CaseQuestionTwo = CaseResFile.GetString("q2");
        }
    }
}
