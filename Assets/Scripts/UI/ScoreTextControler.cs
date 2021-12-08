using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextControler : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] string textBeforeScore = "Score: ";

    private void Start()
    {
        GameMangaer.Instance.OnScoreChange += UpdateText;
    }
    private void OnDestroy()
    {
        if(GameMangaer.Instance != null)
        GameMangaer.Instance.OnScoreChange -= UpdateText;
    }
    private void UpdateText(int score)
    {
        scoreText.text = textBeforeScore + score.ToString();
    }

    
}
