using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    public GameObject sunObject;
    public float cd;

    private void Start()
    {
        InvokeRepeating("SpawnSun", cd, cd);
    }

    void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject, new Vector3(transform.position.x + Random.Range(-.5f, .5f), transform.position.y + Random.Range(0f, .5f), 0), Quaternion.identity);
        mySun.GetComponent<Sun>().dropToField = transform.position.y - 1;
    }
}
