using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{

    public GyroControl gyroControl;

    // Use this for initialization
    void Start ()
    {
		


	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.Translate(Input.acceleration.x * 0.05f, 0, 0);

    }
}
