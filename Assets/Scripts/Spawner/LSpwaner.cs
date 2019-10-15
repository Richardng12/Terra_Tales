using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSpwaner : MonoBehaviour
{
    public List<Building> buildings;
    private List<Column> columnsOnCD = new List<Column>();

    public float spawnTime = 1000f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime) {
            SpawnRandom();
            timer = 0;
        }
    }

    private void SpawnRandom() {
        Building building = buildings[Random.Range(0, buildings.Count)];
        Column column = building.getColumns()[Random.Range(0, building.getColumns().Count)];
        if (column.ifWindowOn() || columnsOnCD.Contains(column)) {
            SpawnRandom();
        } else {
            column.turnOnWindows(true);
            StartCoroutine(waitForPersonLeave(column));
            putColumnOnCD(column);
        }
    }

    private void putColumnOnCD(Column column) {
        columnsOnCD.Add(column);
        StartCoroutine(waitForCD());
    }

    IEnumerator waitForPersonLeave(Column column) {
        yield return new WaitForSeconds(Random.Range(2, 10));
        foreach (Window window in column.getWindows()) {
            window.personLeave();
        }
    }

    IEnumerator waitForCD() {
        yield return new WaitForSeconds(5);
    }
}
