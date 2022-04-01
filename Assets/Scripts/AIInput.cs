using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AIInput : Agent
{

    public GameObject gameController;
    public GameObject shipModel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnEpisodeBegin()
    {
        base.OnEpisodeBegin();
    }

    // Update is called once per frame
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.position);
        sensor.AddObservation(this.transform.rotation);
        sensor.AddObservation(shipModel.GetComponent<ShipController>().GetMomentum());
        sensor.AddObservation(shipModel.GetComponent<ShipController>().GetShootTimer());
    }

    public override void Heuristic(in ActionBuffers actionOut)
    {
        var discreteActionsOut = actionOut.DiscreteActions;

        int isThrust = 0;
        if (Input.GetKey(KeyCode.W)) 
        { 
            isThrust = 1;
        }
        discreteActionsOut[0] = isThrust;

        int isRight = 1;
        if (Input.GetKey(KeyCode.A)) 
        {
            isRight = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRight = 2;
        }
        discreteActionsOut[1] = isRight;

        int isShoot = 0;
        if (Input.GetKey/*Down*/(KeyCode.Space))
        {
            isShoot = 1;
        }
        discreteActionsOut[2] = isShoot;
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        int toMoveForward = actionBuffers.DiscreteActions[0];
        int toMoveRight = actionBuffers.DiscreteActions[1];
        int toShoot = actionBuffers.DiscreteActions[2];

        if (toMoveForward == 1) shipModel.GetComponent<ShipController>().Thrust();
        if (toMoveRight == 0) shipModel.GetComponent<ShipController>().TurnRight(false);
        if (toMoveRight == 2) shipModel.GetComponent<ShipController>().TurnRight(true);
        if (toShoot == 1) shipModel.GetComponent<ShipController>().Shoot();

        if(gameController.GetComponent<GameManager>().GetScore() > gameController.GetComponent<GameManager>().GetScoreThreshold())
        {
            SetReward(gameController.GetComponent<GameManager>().GetRewardAmount());
            EndEpisode();
            Debug.Log("Episode has been ended successfully.");
        }

        if (!(gameController.GetComponent<GameManager>().ShipIsStillAlive()))
        {
            if (gameController.GetComponent<GameManager>().GetScore() <= 0.0f)
            {
                EndEpisode();
                Debug.Log("Episode has been a collosal failure.");
                return;
            }
            SetReward(gameController.GetComponent<GameManager>().GetRewardAmount());
            EndEpisode();
            Debug.Log("Episode has been ended.");
        }
    }
}
