using System;

[Serializable]
public class Score
{
    public string name;
    public string time;
    public string car;

    public Score(string n, string t, string c)
    {
        name = n;
        time = t;
        car = c;
    }
}
