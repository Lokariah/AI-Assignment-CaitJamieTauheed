using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipController : MonoBehaviour
{

    Vector3 momentum = Vector3.zero;
    float acceleration = 10.25f;
    float terminalVelocity = 20.0f;
    float drag = 0.25f;
    float turnSpeed = 90.0f;
    float shootTimerMax = 0.5f;
    float shootTimer = 0.0f;

    float screenRadius = 20.0f; //The distance from 0 to the edge of the screen.
    float leniencyEdgeValue = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer > 0.0f) shootTimer -= Time.deltaTime;

        momentum -= (momentum * 0.95f) * Time.deltaTime;

        this.transform.position += momentum * Time.deltaTime;

        if(this.transform.position.x > screenRadius)
        {
            this.transform.position =  new Vector3(-(screenRadius), this.transform.position.y, 15.0f);
        }
        else if (this.transform.position.x < -screenRadius)
        {
            this.transform.position = new Vector3((screenRadius), this.transform.position.y, 15.0f);
        }
        if (this.transform.position.y > screenRadius)
        {
            this.transform.position = new Vector3(this.transform.position.x, -(screenRadius), 15.0f);
        }
        else if (this.transform.position.y < -screenRadius)
        {
            this.transform.position = new Vector3(this.transform.position.x, (screenRadius), 15.0f);
        }
    }

    public void Thrust()
    {
        //if (momentum < terminalVelocity) momentum += acceleration * Time.deltaTime;
        //if (momentum > terminalVelocity) momentum = terminalVelocity;


        momentum += (this.transform.forward * acceleration * Time.deltaTime);

       // this.transform.position += (this.transform.forward * acceleration) * Time.deltaTime;
        
    }

    public void TurnRight(bool turningRight)
    {
        Vector3 zAxis = new Vector3( 0.0f, 0.0f, 1.0f );
        if (turningRight)
        {
            this.transform.RotateAround(this.transform.position, zAxis, -turnSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.RotateAround(this.transform.position, zAxis, turnSpeed * Time.deltaTime);
        }
    }

    public void Shoot()
    {
        if (shootTimer <= 0.0f)
        {
            //Add shoot code here

            shootTimer = shootTimerMax;
        }
    }
}
