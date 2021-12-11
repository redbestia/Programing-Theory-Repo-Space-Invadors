using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveMenager : MonoBehaviour
{
    private const string scoresWithNicksFileName = "/savefile.json";
    private const string lastNameFile = "/lastNameFile.json";

    public static void SaveScores()
    {
        SaveData data = new SaveData(GameMangaer.Instance.PlayerNick);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + lastNameFile, json);

        FileHandler.SaveToJson(GameMangaer.Instance.ListOfScoreWithNick, scoresWithNicksFileName);
    }

    public static void LoadScores()
    {
        string path = Application.persistentDataPath + lastNameFile;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            GameMangaer.Instance.PlayerNick = data.LastNick;
        }

        GameMangaer.Instance.ListOfScoreWithNick = 
            FileHandler.ReadFromJson<ScoreWithNick>(scoresWithNicksFileName);
    }
}
