

namespace BlameGame
{
    public static class SuspectInteractions
    {

        /// <summary>
        /// Class is used to retrieve info from suspects. Extracted methods to tidy up main game page
        /// </summary>

        public static bool CheckIfSuspectIsCriminal(object selected)
        {
            bool isGuilty;
            SuspectModel selectedSuspect = selected as SuspectModel;

            if (selectedSuspect.isGuilty)
                isGuilty = true;
            else
                isGuilty = false;

            return isGuilty;
        }

        public static string ShowAnswerToAskedQuestion(string buttonName, object selectedItem)
        {
            var selectedSuspect = selectedItem as SuspectModel;
            string answer = $"Suspect {selectedSuspect.suspectId} says:\n";

            switch (buttonName)
            {
                case "btnQ1":
                    answer += selectedSuspect.Answer1;
                    break;
                case "btnQ2":
                    answer += selectedSuspect.Answer2;
                    break;
            }
            return answer;
        }

        public static string InterrogateTheSuspect(object selectedItem)
        {
            //TODO Add a randomizer for interrogation answers
            string result = "Interrogator says:\n";
            var selectedSuspect = selectedItem as SuspectModel;

            if (selectedSuspect.isGuilty)
                result += "He's our guy.\nGet him before it's too late!!!";
            else
                result += "Nope, not the one...";

            return result;
        }
    }
}
