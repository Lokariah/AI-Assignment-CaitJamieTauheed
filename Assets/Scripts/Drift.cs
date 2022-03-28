using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    
    Vector3 momentum;
    int edge;

    float screenRadius = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        float newScale = Random.Range(1.0f, 3.0f);
        this.transform.localScale *= newScale;
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f); //Sets the momentum of the asteroid
        float speed = Random.Range(2.5f, 10.0f);
        momentum = direction * speed;
        edge = (int)Random.Range(0.0f, 4.0f);

        if (edge == 0) //Top
        {
            this.transform.position = new Vector3(Random.Range(-screenRadius, screenRadius), screenRadius, 15.0f);
        }
        else if (edge == 1) //Right
        {
            this.transform.position = new Vector3(screenRadius, Random.Range(-screenRadius, screenRadius), 15.0f);
        }
        else if (edge == 2) //Bottom
        {
            this.transform.position = new Vector3(Random.Range(-screenRadius, screenRadius), -screenRadius, 15.0f);
        }
        else if (edge == 3) //Left
        {
            this.transform.position = new Vector3(-screenRadius, Random.Range(-screenRadius, screenRadius), 15.0f);
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

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
