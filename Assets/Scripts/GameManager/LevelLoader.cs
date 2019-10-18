using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=YMj2qPq9CP8
public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject nextLevelCanvas;
   public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchrously(sceneIndex));
    }

    IEnumerator LoadAsynchrously(int sceneIndex)
    {
        AsyncOperation loader = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loader.isDone)
        {
            float progress = Mathf.Clamp01(loader.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
        slider.value = 0;

    }

    public void HideCanvas()
    {
        nextLevelCanvas.SetActive(false);
    }
}
