using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{

    //Variables
    public GameObject player;
    public float waitTime;
    private float currentTime;
    private bool shot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    public void Update()
    {
        this.transform.LookAt(player.transform);

        if (currentTime == 0)
        {
            Shoot();
        }

        if (shot && currentTime < waitTime)
        {
            currentTime += 1* Time.deltaTime;
        }

        if (currentTime>= waitTime)
        {
            currentTime = 0;
        }
    }

    public void Shoot()
    {
        shot = true;
        Instantiate(gameObject);
        //Debug.Log("shot");
    }
}
