using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject zombie;
    public ZombieTypeProb[] zombieTypes;
    private List<ZombieType> list = new List<ZombieType>();
    public int maxZombie;
    public int spawnedZombie;
    public Slider progress;
    public float deplay = 3;


    private void Start()
    {
        InvokeRepeating("SpawnerZombie", 2, deplay);

        foreach (ZombieTypeProb zom in zombieTypes)
        {
            for (int i = 0; i < zom.prob; i++)
                list.Add(zom.type);
        }

        progress.maxValue = maxZombie;
    }

    private void Update(){
        progress.value = spawnedZombie;

    }

    void SpawnerZombie()
    {
        if(spawnedZombie ==maxZombie)
        {
            return;
        }
        spawnedZombie++;
        int randomSpawn = Random.Range(0, spawnPoints.Length);
        GameObject zombies = Instantiate(zombie, spawnPoints[randomSpawn].position, Quaternion.identity);
        zombies.GetComponent<Zombie>().type = list[Random.Range(0, list.Count)];

        //  int randomNumber = Random.Range(0, spawnPoints.Length);
        // Vector3 offset = Random.insideUnitSphere * 2f;
        // offset.y = 0f;
        // Vector3 spawnPosition = spawnPoints[randomNumber].position + offset;
        // GameObject myZombie = Instantiate(zombie, spawnPosition, Quaternion.identity);
    }
}


[System.Serializable]
public class ZombieTypeProb
{
    public ZombieType type;
    public float prob;
}
