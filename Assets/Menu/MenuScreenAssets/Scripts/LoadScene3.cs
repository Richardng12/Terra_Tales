using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene3 : MonoBehaviour
{
    void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        SceneManager.LoadSceneAsync(3);

		Debug.Log ("You have clicked the button!");
	}


}
