using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class AbstractSpawnableObject : MonoBehaviour
    {
        private int spawnLocation;
        private SpawnerScript spawner;

    public void SetLocation(int location) {
        this.spawnLocation = location;
         }

    public int GetLocation() {

        return spawnLocation;
}

    private void OnDestroy(){}
}
