using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    float time = 0.0f;
    float spawnDelay = 2.0f;
    float previousTimeMod;
    float initialDelay = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        previousTimeMod = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float timeMod = time % spawnDelay;
        if (timeMod < previousTimeMod && time >= initialDelay)
        {
            Instantiate(asteroidPrefab, new Vector3(0.0f, 0.0f, 15.0f), Quaternion.identity);
        }
        previousTimeMod = timeMod;
    }

    public void ResetAsteroids()
    {
        time = 0.0f;
        GameObject[] asteroidArray = GameObject.FindGameObjectsWithTag("Asteroid");
        for (int i = 0; i < asteroidArray.Length; i++)
        {
            Destroy(asteroidArray[i]);
        }
    }

    public GameObject[] GetAsteroids()
    {
        return GameObject.FindGameObjectsWithTag("Asteroid");
    }
}
