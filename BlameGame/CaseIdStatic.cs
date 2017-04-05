

namespace BlameGame
{
    static class CaseIdStatic
    {
        //this class is used for advancing the game to the next level/case and for case construction
        //static int to retain current case id after exiting to main menu or game over
        public static int CaseId { get; set; } = 1;

        public static void IncrementCaseId()
        {
            CaseId++;
        }
    }
}
