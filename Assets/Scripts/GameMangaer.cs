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

    // ENCAPSULATION
    public int Score { get => score; }
    private int score = 0;

    public List<ScoreWithNick> ListOfScoreWithNick = new List<ScoreWithNick>();

    // ENCAPSULATION
    public static GameMangaer Instance { get => instance; }
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

    // ENCAPSULATION
    // ABSTRACTION
    public void AddOneToScore()
    {
        score++;
        OnScoreChange.Invoke(score);
    }

    // ENCAPSULATION
    // ABSTRACTION
    public void ZeroScore()
    {
        SaveScoreToHighScores();
        score = 0;
        OnScoreChange.Invoke(score);
    }

    // ABSTRACTION
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
        ListOfScoreWithNick.Add(new ScoreWithNick(playerNick, score));
        ListOfScoreWithNick.Sort();
        ListOfScoreWithNick.Reverse();

    }
}
