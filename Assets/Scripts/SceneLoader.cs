using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    string nameOfSceneToLoad = "";

    public void LoadThisScene()
    {
        SceneManager.LoadScene(nameOfSceneToLoad);
    }
}
