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
            textToDisplay += (i+1) + ". " + scoresWithNicks[i].Nick + ": "
                + scoresWithNicks[i].Score + "\n";
        }

        highScoresData.text = textToDisplay;
    }
}
