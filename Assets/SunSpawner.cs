using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public GameObject sunObject;

    private void Start()
    {
        SpawnSun();
    }

    void SpawnSun()
    {
       GameObject mysun = Instantiate(sunObject, new Vector3(Random.Range(-4f, 8f), 6, 0), Quaternion.identity);
        mysun.GetComponent<Sun>().dropToField = Random.Range(2f, -3f);
        Invoke("SpawnSun", Random.Range(4, 10));
    }
}
