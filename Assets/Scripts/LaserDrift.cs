using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDrift : MonoBehaviour
{

    Vector3 momentum;
    int edge;

    float timeAlive = 0.0f;
    float lifeTime = 2.5f;
    float screenRadius = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(Vector3.left, -90.0f);
        float speed = 15.0f;
        momentum = this.transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= lifeTime) Destroy(this.gameObject);

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
        if (other.tag != "Player" && other.tag != "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
