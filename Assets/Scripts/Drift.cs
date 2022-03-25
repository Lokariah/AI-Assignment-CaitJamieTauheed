using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{

    Vector3 momentum;
    int edge;
    Vector3 position;

    float screenRadius = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        momentum = new Vector3(Random.Range(1.0f, 360.0f), -90.0f, 0.0f); //Sets the momentum of the asteroid
        edge = (int)Random.Range(0.0f, 4.0f);

        if (edge == 0) //Top
        {
            position = new Vector3(Random.Range(-screenRadius, screenRadius), screenRadius, 15.0f);
        }
        else if (edge == 1) //Right
        {
            position = new Vector3(screenRadius, Random.Range(-screenRadius, screenRadius), 15.0f);
        }
        else if (edge == 2) //Bottom
        {
            position = new Vector3(Random.Range(-screenRadius, screenRadius), -screenRadius, 15.0f);
        }
        else if (edge == 3) //Left
        {
            position = new Vector3(-screenRadius, Random.Range(-screenRadius, screenRadius), 15.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += momentum * Time.deltaTime;

        if (this.transform.position.x > screenRadius)
        {
            this.transform.position = new Vector3(-(screenRadius), this.transform.position.y, 15.0f);
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
}
