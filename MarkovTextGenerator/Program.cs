namespace MarkovTextGenerator;

public class Program
{
    static void Main(string[] args)
    {
        Chain chain = new Chain();

        Console.WriteLine("Welcome to Marky Markov's Random Text Generator!");

        Console.WriteLine("Enter some text I can learn from (enter single ! to finish): ");

        LoadText("sample.txt", chain);
        
        /*while (true)
        {

            Console.Write("> ");

            var line = Console.ReadLine();
            if (line == "!")
                break;

            chain.AddSentence(line);  // Let the chain process this string
        }*/

        // Now let's update all the probabilities with the new data
        chain.UpdateProbabilities();

        // Okay now for the fun part
        Console.WriteLine("Done learning!  Now give me a word and I'll write a sentence based on that word.");

        while (true)
        {
            Console.Write("> ");

            var word = Console.ReadLine() ?? string.Empty;

            if (word == "done")
                break;

            /*var nextWord = chain.GetNextWord(word);
            Console.WriteLine("I predict the next word will be " + nextWord);*/
            string sentence = chain.GenerateSentence(word);
            Console.WriteLine(sentence);
        }

    }

    static void LoadText(string filename, Chain chain)
    {
        int counter = 0;

        string path = Path.Combine(Environment.CurrentDirectory, $"data\\{filename}");

        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            chain.AddSentence(line);
            counter++;
        }
    }
}

