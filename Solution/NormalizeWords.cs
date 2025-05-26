using System;

namespace vCardManager
{
    public class NormalizeWords
    {
        public string CapitalizeWords(string userInput)
        {
            if (userInput == null)
            {
                throw new ArgumentException("SCRIPT_ERROR: User Input can't be null, try again please.");
            }

            string input = userInput.Trim().ToLower();
            string[] nameList = input.Split(' ');

            for (int i = 0; i < nameList.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(nameList[i]))
                {
                    string word = nameList[i];
                    nameList[i] = word.Substring(0, 1).ToUpper() + word.Substring(1);
                }
            }

            return string.Join(" ", nameList);
        }
    }
}
