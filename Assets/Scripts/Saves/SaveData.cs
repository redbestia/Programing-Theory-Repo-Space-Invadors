using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public SaveData(string lastNick)
    {
        LastNick = lastNick;
    }

    public string LastNick = "";
}
