using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class AIInput : Agent
{
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnEpisodeBegin()
    {
        gameController.GetComponent<GameManager>().ResetGame();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (!gameController.GetComponent<GameManager>().ShipIsStillAlive())
        {
            EndEpisode();
            Debug.Log("Episode has been ended.");
        }
    }
}
