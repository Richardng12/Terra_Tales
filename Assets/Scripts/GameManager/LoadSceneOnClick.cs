using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
    //This class is to load a scene without a loading screen
{
 public void loadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
