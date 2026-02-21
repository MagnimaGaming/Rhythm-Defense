using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaning : MonoBehaviour
{
    public GameObject Ground;
     Vector3 NextSpawnPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(Ground, NextSpawnPoint, Quaternion.identity);
        NextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnTile();
        }
    }
}
