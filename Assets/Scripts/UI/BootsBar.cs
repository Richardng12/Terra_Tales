using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsBar : MonoBehaviour
{
    private int bootsHealth = 0;
    public int bootsMaxHealth;
    private bool bootsOnCD = false;

     public float durationCD = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public int getBootsHealth() {
        return bootsHealth;
    }

    public void fillBootsHealth() {
        bootsHealth = bootsMaxHealth;
    }

    public void loseBootsHealth() {
        Debug.Log("Should be losing boots health");
        bootsHealth--;
    }

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

}
