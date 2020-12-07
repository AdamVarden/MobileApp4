using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHeart;
    [SerializeField] float loadDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i< health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;               
            }
            if (i< numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(health == 0)
        {
            SendMessage("HasDied");
            Invoke("ReloadScene", loadDelay);
        }        
    }

    private void OnParticleCollision(GameObject other) 
    {
        if(other.gameObject.tag == "Enemy Laser")
        {
            Debug.Log("Enemy Laser reduced health " + health);
            health -= 1;
        }        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("I was hit");



        if(other.gameObject.tag == "Turret")
        {
            health -= 1;
            Debug.Log("Enemy Turret reduced health " + health);

        }
        if(other.gameObject.tag == "HealthBox")
        {
            if (health < 5)
            {
                health = health + 1;
            }

        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
