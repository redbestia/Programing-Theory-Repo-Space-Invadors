using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class GameMangaer : MonoBehaviour
{
    public string PlayerNick
    {
        get => playerNick;

        set
        {
            if (value != "")
            {
                playerNick = value;
            }
            else
            {
                Debug.Log("PlayerNick was empty and it's automatically set to: " + DefultName);
                playerNick = DefultName;
            }
        }
    }
    [SerializeField] private string playerNick = DefultName;
    private const string DefultName = "NoName";

    public int Score { get => score; }
    private int score = 0;

    public List<ScoreWithNick> ListOfScoreWithNick = new List<ScoreWithNick>();

    //public Dictionary<string, int> HighScores = new Dictionary<string, int>();
    public static GameMangaer Instance
    {
        get
        {
            if (instance != null)
            {
               return instance;
            }
            else
            {
                return null;
            }
        } 
    }
    private static GameMangaer instance;

    public event Action<int> OnScoreChange = delegate { };
    private void Awake()
    {
        SetThisInstanceToStaticIfInstaneIsNull();
        if (instance != null)
        {
            SaveMenager.LoadScores();
        }
    }

    public void AddOneToScore()
    {
        score++;
        OnScoreChange.Invoke(score);
    }

    public void ZeroScore()
    {
        SaveScoreToHighScores();
        score = 0;
        OnScoreChange.Invoke(score);
    }

    private void SetThisInstanceToStaticIfInstaneIsNull()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveScoreToHighScores()
    {
        //HighScores.Add(playerNick, score);
        //HighScores.OrderBy(key => key.Value);
        ListOfScoreWithNick.Add(new ScoreWithNick(playerNick, score));
        ListOfScoreWithNick.Sort();

    }
}
