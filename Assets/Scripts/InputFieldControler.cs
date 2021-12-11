using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldControler : MonoBehaviour
{
    private void Start()
    {
        GetComponent<InputField>().text = GameMangaer.Instance.PlayerNick;
    }
    public void SetPlayerNickToThisInputField()
    {
        GameMangaer.Instance.PlayerNick = GetComponent<InputField>().text;
    }
}
