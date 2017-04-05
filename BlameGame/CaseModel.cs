

namespace BlameGame
{
    class CaseModel
    {
        /// <summary>
        /// Object model for in-game case
        /// </summary>

        public string CaseID { get; set; }
        public string CaseTitle { get; set; }
        public string CaseContent { get; set; }
        public string CaseQuestionOne { get; set; }
        public string CaseQuestionTwo { get; set; }

        public CaseModel(string title, string content, string q1, string q2)
        {
            CaseTitle = title;
            CaseContent = content;
            CaseQuestionOne = q1;
            CaseQuestionTwo = q2;
        }
    }
}
