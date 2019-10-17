using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFade : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
  public void FadeToDialogue(){
      animator.SetTrigger("FadeOut");
      Debug.Log("hi");
  }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void onFadeComplete(){
        
    }
}
