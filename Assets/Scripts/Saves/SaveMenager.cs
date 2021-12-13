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

        FileHandler.SaveToJson(new SaveData(GameMangaer.Instance.PlayerNick), lastNameFile);

        FileHandler.SaveToJson(GameMangaer.Instance.ListOfScoreWithNick, scoresWithNicksFileName);
    }

    public static void LoadScores()
    {

        if (FileHandler.ReadFromJson<SaveData>(lastNameFile) !=null)
        {
            GameMangaer.Instance.PlayerNick = FileHandler.ReadFromJson<SaveData>(lastNameFile).LastNick;
        }


        GameMangaer.Instance.ListOfScoreWithNick = 
            FileHandler.ReadFromJsonToList<ScoreWithNick>(scoresWithNicksFileName);
    }
}
