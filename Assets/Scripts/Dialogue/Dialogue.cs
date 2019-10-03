using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    //name of npc we are talking with
	public string name;

    //Min num of lines, max num of lines
    //Works with DialogueTrigger
	[TextArea(3, 10)]
	public string[] sentences;

}
