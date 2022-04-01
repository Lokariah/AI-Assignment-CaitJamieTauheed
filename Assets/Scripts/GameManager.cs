using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject asteroidSpawner;
    public GameObject shipModel;
    static int score = 0;
    int scoreThreshold = 10000;
    float sessionTime = 0.0f;
    bool resetProcess = false;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Debug.Log("Start Function. Score is " + score);
        sessionTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        sessionTime += Time.deltaTime;
    }

    public  void ResetGame()
    {
        resetProcess = true;
        shipModel.GetComponent<ShipController>().ResetShip();
        asteroidSpawner.GetComponent<AsteroidSpawner>().ResetAsteroids();
        Debug.Log("ResetGame Function. Score is " + score);
        score = 0;
        sessionTime = 0.0f;
        resetProcess = false;
    }

    public bool ShipIsStillAlive()
    {
        return shipModel.GetComponent<ShipController>().CheckIfAlive();
    }

    public void AsteroidDead(float scoreAmount)
    {
        //Debug.Log("A:   AsteroidDead Function - score increase recieved. Score is " + score);
        if(!resetProcess) score += (int)Math.Truncate(scoreAmount);
        //Debug.Log("B:   AsteroidDead Function - score increase recieved. Score is " + score);
    }

    public int GetScore()
    {
        return score;
    }

    public float GetRewardAmount()
    {
        return score / (sessionTime * (float)Math.Pow(10, -2));
    }
    public int GetScoreThreshold()
    {
        return scoreThreshold;
    }
}
