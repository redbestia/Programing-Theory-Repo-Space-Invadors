using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpTextControler : MonoBehaviour
{
    [SerializeField] PlayerHp playerHp;
    [SerializeField] Text scoreText;
    [SerializeField] string textBeforeScore = "Hp: ";

    private void Start()
    {
        playerHp.OnGetDamage.AddListener(UpdateText);
        UpdateText(playerHp.Hp);
    }
    private void OnDestroy()
    {
        if (playerHp != null)
            playerHp.OnGetDamage.RemoveListener(UpdateText);
    }
    private void UpdateText(int hp)
    {
        scoreText.text = textBeforeScore + hp.ToString();
    }
}
