using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionItem : MonoBehaviour
{

    public GameObject[] myObjects;
    private int itemCount;

    void Update()
    {
        itemCount = GameObject.FindGameObjectsWithTag("Tomato").Length +
            GameObject.FindGameObjectsWithTag("Cabbage").Length;
        if (itemCount < 20)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            float[] axisY = { 0.5f, 0.85f };
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 25), axisY[randomIndex], Random.Range(-26, 15));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}