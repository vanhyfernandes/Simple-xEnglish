using System;
using System.Collections.Generic;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {

        Dictionary<int, string> menuOptions = new Dictionary<int, string>(){
            {1,"Verb Tense"},
            {2,"Prepositions"},
            {3,"Pronouns"},
            {4,"Adjectives"},
            {5,"Conditionals"},
            {6,"Phasal Verbs"},
            {7,"Quit"}
        };

        QuestionManager questionManager = new QuestionManager();
        DatabaseManager bdManager = new DatabaseManager();
        bdManager.loadDatabase();

        int option;
        
        do{
            if(menuOptions.Count == 1){
                Console.WriteLine("----------------------------- Game over -----------------------------");
                Console.WriteLine("OMG! You finilized all questions!!");
                break;
            } 
            
            option = ReadUserOption(menuOptions);
            
            if(option != 7){
                Console.WriteLine($"----------------------------- {menuOptions[option]} -----------------------------");
                menuOptions.Remove(option);
                questionManager.handleQuestions(bdManager.getQuestionsByTopic(option));
            }

        }while(option != 7);

        Console.WriteLine($"Total Score: {questionManager.score}");
        Console.WriteLine("Thanks for playing!");

        SplashKit.FreeAllDatabases();
        SplashKit.FreeAllQueryResults();

    }

        private static int ReadUserOption(Dictionary<int, string> menuOptions) {

        int userOption;
        //int counter=1;
        Console.WriteLine();
        Console.WriteLine("------------------------------- Menu --------------------------------");

        foreach( KeyValuePair<int, string> opt in menuOptions )
        {
            Console.WriteLine("{0} - {1}", opt.Key, opt.Value);
        }

        do{
            Console.WriteLine("Choose an option: ");
            try{
                userOption = Convert.ToInt32(Console.ReadLine());
            }catch{
                userOption = -1;
            }

            if(!menuOptions.ContainsKey(userOption)){
                Console.WriteLine($"Please select an option from the menu!");
            }

        }while(!menuOptions.ContainsKey(userOption));

        return userOption;
    }

}
