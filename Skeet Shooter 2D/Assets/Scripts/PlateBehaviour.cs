using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    public float timeScaleOn = 0.3f;
    public float timeScaleOff = 1.0f;
    private float timer;
    

	// Use this for initialization
	void Start ()
    {
        PAProximity.messageReceiver = gameObject;
        OnProximityChange(PAProximity.proximity);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //GameObject thePlate = GameObject.FindGameObjectWithTag("Plates");
        //Rigidbody rb = thePlate.GetComponent<Rigidbody>();
        //rb.drag = 2;
        

    }

    void OnProximityChange(PAProximity.Proximity proximity)
    {
        Time.timeScale = ((proximity == PAProximity.Proximity.NEAR) ? timeScaleOn : timeScaleOff);
    }

    public void ActivateSlowMotion()
    {
        Time.timeScale = 0.5f;

    }

    public void DeactivateSlowMotion()
    {
        Time.timeScale = 1.0f;

    }
}
