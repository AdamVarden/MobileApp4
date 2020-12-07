using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    int health;
    int scoreAmount = 10000;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Level 1")) 
         {
             health = 16;
         }
 
        else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Level 2"))
         {
             health = 20;
         }

        else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Level 3"))
         {
             health = 28;
         }                 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) 
    {
        --health;
        if(health == 0)
        {
            score.AddScore(scoreAmount);
            Destroy(gameObject);
            
        }

    }
}
