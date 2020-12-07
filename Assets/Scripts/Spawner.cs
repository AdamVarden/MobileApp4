using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;
    private int waveNumber =0;
    [SerializeField] int enemySpawnAmount = 0;
    public int enemiesKilled  {get;set;}
    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[transform.childCount];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
        Instantiate(enemy,spawners[i].transform.position,spawners[i].transform.rotation);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled >= enemySpawnAmount)
        {
            //Debug.Log("Enemies Killed "+enemiesKilled);
            NextWave();
        }

    }

    private void StartWave()
    {
        waveNumber = 1;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
    public void NextWave()
    {
        waveNumber++;
        enemiesKilled =0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }    
}
