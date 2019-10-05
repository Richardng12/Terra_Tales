using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeCounter : MonoBehaviour
{
    public int treesPlanted;

    public Text treeText;

    public float fadeOutTime;
    // Start is called before the first frame update
    void Start()
    {
        treesPlanted = 0;
    }

    public void updateAndDisplayTreeCounter()
    {
        treeText.color = Color.yellow;

        treesPlanted++;
        treeText.text = "Planted " + treesPlanted + "/10 Trees";
        StartCoroutine(TextFadeOutRoutine());
    }

    private IEnumerator TextFadeOutRoutine()
    {
        Color color = treeText.color;

        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            treeText.color = Color.Lerp(color, Color.clear, Mathf.Min(1, t / fadeOutTime));

            yield return null;
        }
    }
}
