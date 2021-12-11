using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public SaveData(/*List<ScoreWithNick> listOfScoreWithNick,*/ string lastNick)
    {
        //ListOfScoreWithNick = listOfScoreWithNick.ToArray();
        LastNick = lastNick;
    }

    //public ScoreWithNick[]  ListOfScoreWithNick;
    public string LastNick = "";
}
