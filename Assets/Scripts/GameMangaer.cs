using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    }

    public void AddOneToScore()
    {
        score++;
        OnScoreChange.Invoke(score);
    }

    public void ZeroScore()
    {
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


}
