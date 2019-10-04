using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenFade : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(fadeOut()); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(2f);
        float duration = 2f;
        float counter = 0;
        //Get current color
        Color spriteColor = image.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);

            //Change alpha only
            image.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
        image.enabled = false;
    }

}
