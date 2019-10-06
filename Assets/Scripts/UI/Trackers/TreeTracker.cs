using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeTracker : MonoBehaviour, ITracker<int>
{
    private int[] treesPlanted = new int[1];

    public Text text;

    public float fadeOutTime;
    // Start is called before the first frame update
    void Start()
    {
        treesPlanted[0] = 0;
    }

    public void UpdateAndDisplayTaskCounter(int i = 0)
    {
        treesPlanted[i]++;
        text.text = "Planted " + treesPlanted[i] + "/10 Trees";
        StartCoroutine(TextFadeOutRoutine());
    }

    public IEnumerator TextFadeOutRoutine()
    {
        Color color = text.color;

        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(color, Color.clear, Mathf.Min(1, t / fadeOutTime));

            yield return null;
        }
    }
}
