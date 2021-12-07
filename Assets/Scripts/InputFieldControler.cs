using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldControler : MonoBehaviour
{
    public void SetPlayerNickToThisInputField()
    {
        GameMangaer.Instance.PlayerNick = GetComponent<InputField>().text;
    }
}
