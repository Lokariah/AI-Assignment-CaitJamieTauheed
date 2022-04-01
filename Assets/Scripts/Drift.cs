using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    public GameObject gameController;

    const float SCALE_MAX = 4.0f;
    const float SCALE_MIN = 0.5f;
    const float SPEED_MAX = 10.0f;
    const float SPEED_MIN = 2.5f;


    Vector3 momentum;
    int edge;
    float scaleAmount = 0.0f;
    float screenRadius = 20.0f;
    int baseScore = 100;

    // Start is called before the first frame update
    void Start()
    {
        scaleAmount = Random.Range(SCALE_MIN, SCALE_MAX);
        this.transform.localScale *= scaleAmount;
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f); //Sets the momentum of the asteroid
        float speed = Random.Range(SPEED_MIN, SPEED_MAX);
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
        if (other.tag != "Asteroid")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Function - score increase sent.");
        gameController.GetComponent<GameManager>().AsteroidDead(scaleAmount * baseScore);
    }
}
