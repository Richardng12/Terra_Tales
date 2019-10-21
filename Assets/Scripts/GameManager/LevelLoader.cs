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
    public string[] facts;
    public Text tip;

    // Pulsating text for the loading text
    void Update()
    {
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
    }

    // Loads the level asynchrousnly and applies a tip or a fact depending on
    // the scene that is loading
    public void LoadLevel(int sceneIndex)
    {
        Time.timeScale = 1;
        loadingScreen.SetActive(true);
        switch (sceneIndex)
        {
            // If the scene is forest level it should get a forest tip
            case 2:
                tip.text ="Tip: "+tips[0];
                break;
            // If the scene is ocean level it should get a ocean tip
           case 3:
                tip.text = "Tip: " + tips[1];
                break;
            // If the scene is city level it should get a city tip
                case 4:
                tip.text = "Tip: " + tips[2];
                break; 
            // all other scenes give a random fact
            default:
                tip.text ="Did you know? " + facts[Random.Range(0, facts.Length)];
                break;
        }
        // Starts the loading of a scene on a Coroutine
        StartCoroutine(LoadAsynchrously(sceneIndex));
    }

    IEnumerator LoadAsynchrously(int sceneIndex)
    {
        // Artificial delay so user can read the tips in the loading screen
        yield return new WaitForSeconds(2);

        AsyncOperation loader = SceneManager.LoadSceneAsync(sceneIndex);
        // Checks if the loading is done or not
        while (!loader.isDone)
        {
            // Sets the progress bar to the value complete percentage
            float progress = Mathf.Clamp01(loader.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
        // when done loading screen is set back to false
        loadingScreen.SetActive(false);
    }
    // Hides the set canvas
    public void HideCanvas()
    {
        nextLevelCanvas.SetActive(false);
    }
}
