DisplayMainMenu();

void DisplayMainMenu()
{
    Console.WriteLine("Welcome to Stemming Application");
    Console.WriteLine("Please type in the set of words that needs stemming : -");
    var input = Console.ReadLine();

    Console.WriteLine("Please type in the set of words required to find stemming Frequency : -");

    var frequencyWords = Console.ReadLine();
    if (!string.IsNullOrEmpty(input) || !string.IsNullOrEmpty(frequencyWords))
        GetStemmedResults(input, frequencyWords);
}



void GetStemmedResults(string input , string frequencyWords )
{
    
    var results = input.Split();

    var StemDictionary = new Dictionary<string, int>();
    var stemWord = frequencyWords.Split();


    foreach (var item in results)
    {

        foreach (var word in stemWord)
        {
            var stemresult = item.ToLower().Contains(word.ToLower());

            if (stemresult)
            {
                var excess = item.ToLower().Trim(word.ToLower().ToCharArray());
                if (IsValidStem(excess))
                {
                    if (StemDictionary.ContainsKey(word))
                    {
                        StemDictionary[word]++;
                    }
                    else
                    {
                        StemDictionary.Add(word, 1);
                    }
                }
            }

        }

    }

}
 
bool IsValidStem(string excess)
{
    if (excess.Length == 0)
        return true;
    var extra = new List<string>() {"s","es","ers","ir" ,"lier" ,"ness","lies","ify", "ification" ,"y","ing", "dly" };
    foreach(var item in extra)
    {
    if( string.Equals(item, excess, StringComparison.OrdinalIgnoreCase))
         return true;
    }
   
    return false;
}


