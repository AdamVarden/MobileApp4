using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject boss;
    public GameObject MainCamera;
    [SerializeField] int bossSpawnAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[transform.childCount];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }


    private void SpawnBoss()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
        Instantiate(boss,spawners[i].transform.position,spawners[i].transform.rotation);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            MainCamera.GetComponent<UnityStandardAssets.Utility.WaypointProgressTracker>().enabled = false;
            SpawnBoss();
            GetComponent<Collider>().enabled = false;

        }
    }
}
