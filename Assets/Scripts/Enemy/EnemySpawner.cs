using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform parentOfEnemies;
    [SerializeField] private List<GameObject> listOfEnemyPrefabs;
    [SerializeField] private float lenghtOfSpawnField = 70;
    [SerializeField] private float startMinSpawnTime = 2;
    [SerializeField] private float endMinSpawnTime = 1;
    [SerializeField] private float startMaxSpawnTime = 5;
    [SerializeField] private float endMaxSpawnTime = 1.5f;
    [SerializeField] private float timeWhenMaxSpawnRate = 60;

    private float lastSpawnTime = 0;
    private float randomSpawnTime = 0;
    private float timeOfStartThis = 0;

    private void Start()
    {
        timeOfStartThis = Time.time;
    }
    private void Update()
    {
        if(lastSpawnTime+randomSpawnTime<Time.time)
        {
            Spawn();
            randomSpawnTime = CreateRandomSpawnTime();
            lastSpawnTime = Time.time;
        }
    }

    private void Spawn()
    {
        Instantiate(listOfEnemyPrefabs[Random.Range(0, listOfEnemyPrefabs.Count)],
            transform.position +new Vector3(Random.Range(-lenghtOfSpawnField, lenghtOfSpawnField + 1),0)
            ,Quaternion.Euler(new Vector3(0,180,0)),parentOfEnemies);
    }

    float CreateRandomSpawnTime()
    {
        return Random.Range(CurrentSpawnTime(startMinSpawnTime,endMinSpawnTime),
            CurrentSpawnTime(startMaxSpawnTime,endMaxSpawnTime));
    }

    // ABSTRACTION
    float CurrentSpawnTime(float start,float end)
    {
        if (Time.time - timeOfStartThis < timeWhenMaxSpawnRate)
        {
            return start - ((start - end) / timeWhenMaxSpawnRate * (Time.time - timeOfStartThis));
        }
        else
        {
            return end;
        }
    }
}
