using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserInput : MonoBehaviour
{
    //public ShipController ship; //May not need this. Can access the ship through the gameobject.
    public GameObject shipModel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            shipModel.GetComponent<ShipController>().Thrust();
        }

        if (Input.GetKey(KeyCode.A))
        {
            shipModel.GetComponent<ShipController>().TurnRight(false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            shipModel.GetComponent<ShipController>().TurnRight(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipModel.GetComponent<ShipController>().Shoot();
        }
    }
}
