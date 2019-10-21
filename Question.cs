using System.Collections.Generic;
public class Question {
    private int id;
    private int type;
    private string question;
    private string answer;

    public List<string> options = new List<string>();

    public int Id {
        get{ return this.id; }
        set{ this.id = value; }
    }

    public int Type {
        get{ return this.type; }
        set{ this.type = value; }
    }

    public string Questionn {
        get{ return this.question; }
        set{ this.question = value; }
    }

    public string Answer {
        get{ return this.answer; }
        set{ this.answer = value; }
    }

    public List<string> Options {
        get{ return this.options; }
        set{ this.options = value; }
    }

    public Question(int id, int type, string question, string answer, List<string> options){
        this.id = id;
        this.question = question;
        this.answer = answer;
        this.options = options;
    }

    public Question(){}

    public override string ToString(){
        return "id: " + id + " Question: " + question + " Answer:" + answer + " Opt1: " + options[0] + " Opt2: " + options[1] + "  Opt3: " + options[2] + "  Opt4: " + options[3];
    }

}