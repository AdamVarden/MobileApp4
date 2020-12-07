using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turrets : MonoBehaviour
{
    [SerializeField] GameObject explosionFx;
    int scoreAmount = 100;
    Spawner spawn;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<Spawner>();
        score = GameObject.Find("Score").GetComponent<Score>();

    }

    private void OnParticleCollision(GameObject other) 
    {
        Debug.Log("Enemy Killed by Particle Effect");
        //GameObject fx = Instantiate(explosionFx,transform.position,Quaternion.identity);
        //spawn.enemiesKilled++;
        score.AddScore(scoreAmount);
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            score.AddScore(scoreAmount);

        }        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
