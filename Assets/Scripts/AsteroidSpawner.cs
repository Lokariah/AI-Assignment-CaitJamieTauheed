using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    float time = 0.0f;
    float spawnDelay = 2.0f;
    float previousTimeMod;
    
    // Start is called before the first frame update
    void Start()
    {
        previousTimeMod = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float timeMod = time % 2.0f;
        if (timeMod < previousTimeMod && time >= 3.90f) Instantiate(asteroidPrefab, new Vector3(0.0f, 0.0f, 15.0f), Quaternion.identity);
        previousTimeMod = timeMod;
    }

    public void ResetAsteroids()
    {
        time = 0.0f;
        GameObject[] asteroidArray = GameObject.FindGameObjectsWithTag("Asteroid");
        if (asteroidArray.Length > 0)
        {
            for (int i = 0; i < asteroidArray.Length; i++)
            {
                Destroy(asteroidArray[i]);
            }
        }

        GameObject[] laserArray = GameObject.FindGameObjectsWithTag("Laser");
        if (laserArray.Length > 0)
        {
            for (int i = 0; i < laserArray.Length; i++)
            {
                Destroy(laserArray[i]);
            }
        }
    }

    public GameObject[] GetAsteroids()
    {
        return GameObject.FindGameObjectsWithTag("Asteroid");
    }
}
