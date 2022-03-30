using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject asteroidSpawner;
    public GameObject shipModel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void ResetGame()
    {
        shipModel.GetComponent<ShipController>().ResetShip();
        asteroidSpawner.GetComponent<AsteroidSpawner>().ResetAsteroids();
    }

    public bool ShipIsStillAlive()
    {
        return shipModel.GetComponent<ShipController>().CheckIfAlive();
    }
}
