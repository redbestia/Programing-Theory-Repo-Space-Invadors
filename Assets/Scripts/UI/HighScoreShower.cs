using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreShower : MonoBehaviour
{
    [SerializeField] Text highScoresData;
    [SerializeField] int numberOfHighScores = 15;
    int realNumberOfHighScores = 0;
    string textToDisplay ="";

    
    private void Start()
    {
        var scoresWithNicks = GameMangaer.Instance.ListOfScoreWithNick;
        if (scoresWithNicks.Count > numberOfHighScores)
        {
            realNumberOfHighScores = numberOfHighScores;
        }
        else
        {
            realNumberOfHighScores = scoresWithNicks.Count;
        }

        for (int i = 0; i < realNumberOfHighScores; i++)
        {
            textToDisplay += "1. " + scoresWithNicks[i].Nick + ": "
                + scoresWithNicks[i].Score.ToString() + "\n";
        }

        highScoresData.text = textToDisplay;

        //if (scoresWithNicks.Count < numberOfHighScores)
        //{
        //    for (int i = 0; i < scoresWithNicks.Count; i++)
        //    {
        //        textToDisplay += "1. " + scoresWithNicks[i].Nick + ": "
        //            + scoresWithNicks[i].Score.ToString() + "\n";
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < numberOfHighScores; i++)
        //    {
        //        textToDisplay += "1. " + scoresWithNicks[i].Nick + ": "
        //            + scoresWithNicks[i].Score.ToString() + "\n";
        //    }
        //}
    }
}
