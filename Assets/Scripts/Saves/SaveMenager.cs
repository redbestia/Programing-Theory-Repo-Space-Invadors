using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenager : MonoBehaviour
{
    private const string fileName = "/savefile.json";

    public static void SaveScores()
    {
        SaveData data = new SaveData(GameMangaer.Instance.ListOfScoreWithNick, 
            GameMangaer.Instance.PlayerNick);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + fileName, json);
    }

    public static void LoadScores()
    {
        string path = Application.persistentDataPath + fileName;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (data.ListOfScoreWithNick != null)
            {
                GameMangaer.Instance.ListOfScoreWithNick = data.ListOfScoreWithNick;
            }
            GameMangaer.Instance.PlayerNick = data.LastNick;
        }
    }
}
