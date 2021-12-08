using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
   public void GamePause()
    {
        Time.timeScale = 0;
    }
    public void GameUnpause()
    {
        Time.timeScale = 1;
    }
}
