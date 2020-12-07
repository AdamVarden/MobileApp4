using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightBehaviour : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float xSpeed = 5.0f;
    // [SerializeField] float ySpeed = 5.0f;
    [SerializeField] float hClamp = 25f;
    [SerializeField] float vClamp = 10f;
    [Header("Position Factor")]
    [SerializeField] float positionYawFactor = 1.0f;
    [SerializeField] float positionPitchFactor = -1.0f;
    [Header("Control Factor")]
    [SerializeField] float controlPitchFactor = -20f;//player presses up/down how much does the nose tilt
    [SerializeField] float controlRollFactor = -40f;

    [SerializeField] GameObject[] lasers;

    float horizontalThrow, verticalThrow;
    bool controlsActive;
    void Start()
    {
        controlsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsActive)
        {
            ProcessTranslation();//left, right, up, down
            ProcessRotation();
            ProcessFiring();
        }
        

    }

    private void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }




    private void SetLasersActive(bool IsActive)
    {
        foreach(GameObject laser in lasers) 
        {
            //laser.SetActive(IsActive);//deactivates particle effect
            //find emission element and deacivate that
            var emissionElement = laser.GetComponent<ParticleSystem>().emission;
            emissionElement.enabled = IsActive;
        }
    }

    private void ProcessRotation()
    {
        //order of setting pitch,yaw and roll is important
        //set yaw, pitch first
        float pitch = transform.localPosition.y * positionPitchFactor +
                       verticalThrow * controlPitchFactor;//x
        float yaw = transform.localPosition.x * positionYawFactor;//y
        float roll = horizontalThrow * controlRollFactor;//z

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
    }
    private void HasDied()//call by string reference
    {
        //print("player has lost health - may die!!");
        controlsActive = false;
    }

    private void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        //Debug.Log("hThrow: " + horizontalThrow);
        float xOffset = horizontalThrow * xSpeed;
        float yOffset = verticalThrow * xSpeed;

        //Mathf.clamp(x, -Limit, +Limit)
        float xPosition = Mathf.Clamp(transform.localPosition.x + xOffset, -hClamp, hClamp);
        float yPosition = Mathf.Clamp(transform.localPosition.y + yOffset, -vClamp, vClamp);
        //need to figure out what new position is once offset is known.
        transform.localPosition = new Vector3(xPosition,
                                               yPosition,
                                                transform.localPosition.z);
    }
}
