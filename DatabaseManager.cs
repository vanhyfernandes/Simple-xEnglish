using System;
using SplashKitSDK;
using System.Collections.Generic;

public class DatabaseManager {
    QueryResult result;
    Database my_db;

    public DatabaseManager(){}
    public void loadDatabase(){
        /*
            Topics code: 
            1 - Verb Tense
            2 - Prepositions
            3 - Pronouns
            4 - Adjectives
            5 - Conditionals
            6 - Phasal Verbs
        */

        my_db = SplashKit.OpenDatabase("english_db", "english.sql");
        my_db.RunSql("CREATE TABLE questions (id INTEGER PRIMARY KEY, topic INTEGER, question TEXT, answer TEXT, opt1 TEXT, opt2 TEXT, opt3 TEXT, opt4 TEXT);");
        
        result = my_db.RunSql("SELECT * FROM questions;");

        if(!result.HasRow){
            loadVerbTenseData();
            loadPrepositionsData();
            loadPronounsData();
            loadAdjectivesData();
            loadConditionalsData();
            loadPhasalVerbsData();
        }
    }

    public List<Question> getQuestionsByTopic(int topic){
        List<Question> questions = new List<Question>();
        Question question;
        result = my_db.RunSql($"SELECT * FROM questions WHERE topic = {topic};");

        do{
            question = new Question();
            question.Id = result.QueryColumnForInt(0);
            question.Type = result.QueryColumnForInt(1);
            question.Questionn = result.QueryColumnForString(2);
            question.Answer = result.QueryColumnForString(3);
            question.Options.Add(result.QueryColumnForString(4));
            question.Options.Add(result.QueryColumnForString(5));
            question.Options.Add(result.QueryColumnForString(6));
            question.Options.Add(result.QueryColumnForString(7));
            questions.Add(question);
        }while(result.GetNextRow());

        return questions;
    }

    public void loadVerbTenseData(){
        my_db.RunSql("INSERT INTO questions VALUES (001,1,\"She ____ (be) a beutiful woman!\",\"is\",\"are\",\"be\",\"is\",\"am\");");
        my_db.RunSql("INSERT INTO questions VALUES (002,1,\"Maria ____ (drive) her kids to football practise every Monday.\",\"drives\",\"drive\",\"driven\",\"drove\",\"drives\");");
        my_db.RunSql("INSERT INTO questions VALUES (003,1,\"I ____ (love) the idea of going to the beach next Sunday.\",\"love\",\"loved\",\"loves\",\"love\",\"loving\");");
        my_db.RunSql("INSERT INTO questions VALUES (004,1,\"____ you ____ (drink) coffee?\",\"Do/drink\",\"do/drink\",\"Does/drink\",\"Do/drink\",\"Do/drank\");");
        my_db.RunSql("INSERT INTO questions VALUES (005,1,\"Julia ____ (not like) soft drink.\",\"doesn't like\",\"doesn't like\",\"not like\",\"don't like\",\"is liking\");");
    }

    public void loadPrepositionsData(){
        my_db.RunSql("INSERT INTO questions VALUES (006,2,\"I'll meet you tomoroow ____ library ____ 9am.\",\"in/at\",\"on/about\",\"at/at\",\"at/in\",\"in/at\");");
        my_db.RunSql("INSERT INTO questions VALUES (007,2,\"My brother is very good ____ playing futbool!\",\"at\",\"at\",\"on\",\"in\",\"of\");");
        my_db.RunSql("INSERT INTO questions VALUES (008,2,\"The team is afraid ____ losing the match ____ Saturday.\",\"of/on\",\"at/on\",\"of/on\",\"about/at\",\"in/during\");");
        my_db.RunSql("INSERT INTO questions VALUES (009,2,\"Sorry teacher, I apologize ____ being late!\",\"for\",\"to\",\"about\",\"of\",\"for\");");
        my_db.RunSql("INSERT INTO questions VALUES (010,2,\"Where are you ____ ?\",\"from\",\"to\",\"of\",\"from\",\"about\");");
    }

    public void loadPronounsData(){
        my_db.RunSql("INSERT INTO questions VALUES (011,3,\"My brothers drive me crazy, but I love ____ .\",\"them\",\"they\",\"them\",\"it\",\"he\");");
        my_db.RunSql("INSERT INTO questions VALUES (012,3,\"Hey!! It's ____ , give that to ____ !\",\"mine/me\",\"my/me\",\"mine/I\",\"mine/me\",\"us/him\");");
        my_db.RunSql("INSERT INTO questions VALUES (013,3,\"Is that car ____ ? Yes, it's ____ .\",\"yours/mine\",\"you/my\",\"yours/mine\",\"yourself/my\",\"they/theirs\");");
        my_db.RunSql("INSERT INTO questions VALUES (014,3,\"My mother bought ____ car last year.\",\"her\",\"she\",\"its\",\"herself\",\"her\");");
        my_db.RunSql("INSERT INTO questions VALUES (015,3,\"Is ____ your mother?\",\"she\",\"she\",\"her\",\"his\",\"hers\");");
    }

    public void loadAdjectivesData(){
        my_db.RunSql("INSERT INTO questions VALUES (016,4,\"What is the correct adjective of ACCIDENT ?\",\"Accidental\",\"Accidenty\",\"Accidental\",\"Accidentful\",\"Accidentic\");");
        my_db.RunSql("INSERT INTO questions VALUES (017,4,\"What is the correct adjective of LENGTH ?\",\"Long\",\"Lenthble\",\"Longthy\",\"Length\",\"Long\");");
        my_db.RunSql("INSERT INTO questions VALUES (018,4,\"What is the correct adjective of DANGER ?\",\"Dangerous\",\"Dangerous\",\"Dangerly\",\"Dangerble\",\"Dangeric\");");
        my_db.RunSql("INSERT INTO questions VALUES (019,4,\"What is the correct adjective of WIND ?\",\"Windy\",\"Windal\",\"Windy\",\"Windful\",\"Wind\");");
        my_db.RunSql("INSERT INTO questions VALUES (020,4,\"My sister is ____ (tall) than me\",\"taller\",\"more tall\",\"taller\",\"tallest\",\"most tall\");");
    }

    public void loadConditionalsData(){
        my_db.RunSql("INSERT INTO questions VALUES (021,5,\"If I ____ (go), I ____ (go) to the cinema.\",\"go/will go\",\"go/go\",\"go/will go\",\"went/will go\",\"go/would go\");");
        my_db.RunSql("INSERT INTO questions VALUES (022,5,\"If he ____ (come) today, I ____ (be) surprised.\",\"comes/will be\",\"come/will be\",\"came/will be\",\"comes/would be\",\"comes/will be\");");
        my_db.RunSql("INSERT INTO questions VALUES (023,5,\"If the weather ____ (not improve), we ____ (not have) a picnic.\",\"doesn't improve/won't have\",\"don't improve/will not have\",\"doesn't improve/won't have\",\"improves/will have\",\"doesn't improve/will not have\");");
        my_db.RunSql("INSERT INTO questions VALUES (024,5,\"I ____ (feel) sick if I ____ (eat) this cake.\",\"will feel/eat\",\"feel/will eat\",\"felt/will eat\",\"will feel/ate\",\"will feel/eat\");");
        my_db.RunSql("INSERT INTO questions VALUES (025,5,\"I ____ (go) to the party if I ____ (be) invited.\",\"will go/am\",\"will go/am\",\"go/be\",\"won't go/am\",\"go/will be\");");
    }

    public void loadPhasalVerbsData(){
        my_db.RunSql("INSERT INTO questions VALUES (026,6,\"I don't know where my keys are. I must look ____ them.\",\"for\",\"up\",\"for\",\"down\",\"in\");");
        my_db.RunSql("INSERT INTO questions VALUES (027,6,\"They came ____ to Melbourne last summer.\",\"over\",\"over\",\"across\",\"out\",\"in\");");
        my_db.RunSql("INSERT INTO questions VALUES (028,6,\"Turn ____ the lights when you go to bed.\",\"off\",\"out\",\"down\",\"away\",\"off\");");
        my_db.RunSql("INSERT INTO questions VALUES (029,6,\"My birthday is coming ____ next week.\",\"up\",\"away\",\"in\",\"on\",\"up\");");
        my_db.RunSql("INSERT INTO questions VALUES (030,6,\"We need to get ____ for our presentation on Monday.\",\"together\",\"across\",\"out\",\"up\",\"together\");");
    }
}








/*


           loadVerbTenseData();
           loadPrepositionsData();
           loadPronounsData();
           loadAdjectivesData();
           loadConditionalsData();
           loadPhasalVerbsData();



 */