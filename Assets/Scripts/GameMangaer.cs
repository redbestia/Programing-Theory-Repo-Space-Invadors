using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaer : MonoBehaviour
{
    [SerializeField]
    public string PlayerNick
    {
        get => playerNick;

        set
        {
            if (value != "")
            {
                value = playerNick;

            }
            else
            {
                Debug.Log("PlayerNick was empty and it's automatically set to: " + DefultName);
                value = DefultName;
            }
        }
    }
    [SerializeField]
    private string playerNick = DefultName;
    private const string DefultName = "NoName";

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
                Debug.LogError("Instance of GameMenager is Null");
                return null;
            }
        } 
    }
    private static GameMangaer instance;

    private void Awake()
    {
        SetThisInstanceToStaticIfInstaneIsNull();
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
