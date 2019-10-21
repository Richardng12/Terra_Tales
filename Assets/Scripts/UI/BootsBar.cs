using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BootsBar : MonoBehaviour
{
    private int bootsHealth = 0;
    public int bootsMaxHealth;
    
    // cooldown properties allow boots to have a second or two of invulnerability after taking damage
    private bool bootsOnCD = false;
    public float durationCD = 2f;

    public Slider bootsBar;
    
    // Start is called before the first frame update
    void Start()
    {
        if(bootsBar != null)
        bootsBar.maxValue = bootsMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // every second, update the slider value with the current boots health
        StartCoroutine(setSliderValue(bootsHealth));
    }

     public int getBootsHealth() {
        return bootsHealth;
    }

    public void fillBootsHealth() {
        bootsHealth = bootsMaxHealth;
    }

    public void loseBootsHealth() {
        bootsHealth--;
    }

    // boots go on CD so it doesn't take damage during this period
    public void putOnCD() {
        bootsOnCD = true;
        StartCoroutine(waitForCD());
    }

    public bool isOnCD() {
        return bootsOnCD;
    }
    
    IEnumerator waitForCD() {
        yield return new WaitForSeconds(durationCD);
        bootsOnCD = false;
    }

    IEnumerator setSliderValue(float v) {
        yield return new WaitForSeconds(0f);
        if (bootsBar != null)
            bootsBar.value = v;
    }
}
