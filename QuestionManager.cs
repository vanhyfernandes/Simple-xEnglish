using System.Collections.Generic;
using System;
using SplashKitSDK;
public class QuestionManager{
    public int score=0;

    public void handleQuestions(List<Question> topicQuestion){

        topicQuestion.ForEach(delegate(Question question)
        {
            handleQuestion(question);
            Console.WriteLine("----------------------------------------------------------------------");
        });

    }

    private void handleQuestion(Question question){
        Console.WriteLine($"Question: {question.Questionn}");
        string userAnswer = printReadOptions(question.Options);
        verifyAnswer(userAnswer, question.Answer);
    }

    private static string printReadOptions(List<string> options) {

        int answer;
        int counter=1;

        Console.WriteLine();
        Console.WriteLine("-> Options");

        options.ForEach(delegate(String opt)
        {
            Console.WriteLine($"{counter} - {opt}");
            counter++;
        });

        do{
            Console.WriteLine("Choose the right option: ");
            try{
                answer = Convert.ToInt32(Console.ReadLine());
            }catch{
                answer = -1;
            }

            if(answer < 1 || answer > 4){
                Console.WriteLine("Please select an option between 1 and 4!");
            }

        }while(answer < 1 || answer > 4);

        return options[answer-1];
    }

    public void verifyAnswer(string userAnswer, string correctAnswer){
        if(String.Equals(userAnswer, correctAnswer)){
            Console.WriteLine("-> Correct Answer =)");
            Console.WriteLine("Congrats! you have given the correct answer!!");
            score++;
        } else {
            Console.WriteLine("-> Incorrect Answer =(");
            Console.WriteLine($"Sorry! The correct answer is: {correctAnswer}");
        }
        Console.WriteLine($"Score: {score}");
    }
}