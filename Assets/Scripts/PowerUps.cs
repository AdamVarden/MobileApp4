using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private Transform powerUpPosition;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject powerUp;
    private float respawnCountdown ;
    [SerializeField] private float respawnTime = 2;


    private void Update() 
    {     
        Debug.Log("Update Method PowerUps Countdown: " + respawnCountdown);
        if (respawnCountdown > 0)
        {
            respawnCountdown -= Time.deltaTime;
            Debug.Log(respawnCountdown);
        }

        if (respawnCountdown == 0)
        {
            Respawn();
        } 
    }

    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("If statement Hit the player");

            powerUp.SetActive(false); // false to hide, true to show
            respawnCountdown = respawnTime;
            Debug.Log("Setting Respawn Time after collision " + respawnCountdown);
        }
        
    }

    private void Respawn()
    {
        Debug.Log("Respawn Has Been");
        powerUp.transform.position = spawnPoint.transform.position;
        powerUp.SetActive(true); // false to hide, true to show
    }
}
