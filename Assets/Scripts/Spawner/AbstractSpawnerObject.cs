using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class AbstractSpawnableObject : MonoBehaviour
    {
        private int spawnLocation;

    public void SetLocation(int location) {
        this.spawnLocation = location;
         }

    public int GetLocation() {
        return spawnLocation;
}

     public abstract void OnDestroy();
}
