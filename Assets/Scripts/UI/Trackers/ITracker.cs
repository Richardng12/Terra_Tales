using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 interface ITracker<T>
{
    void UpdateAndDisplayTaskCounter(T i);

    IEnumerator TextFadeOutRoutine();

    int[] GetTasks();
}
    
