using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreWithNick : IComparable<ScoreWithNick>
{
    public ScoreWithNick(string nick,int score)
    {
        Nick = nick;
        Score = score;
    }

    public string Nick ;
    public int Score;

    public int CompareTo(ScoreWithNick other)
    {
        if (other == null)
        {
            return 1;
        }
        else
            return Score.CompareTo(other.Score);
    }
}
