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
    public Text loadingText;
    public string[] tips;
    public Text tip;

    void Update()
    {
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
    }

    public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        switch (sceneIndex)
        {
            case 2:
                tip.text = tips[1];
                break;
            case 3:
                tip.text = tips[2];
                break;
            case 4:
                tip.text = tips[3];
                break;
            default:
                tip.text = tips[0];
                break;
        }
        StartCoroutine(LoadAsynchrously(sceneIndex));
    }

    IEnumerator LoadAsynchrously(int sceneIndex)
    {
        yield return new WaitForSeconds(2);

        AsyncOperation loader = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loader.isDone)
        {
            float progress = Mathf.Clamp01(loader.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
    }

    public void HideCanvas()
    {
        nextLevelCanvas.SetActive(false);
    }
}
