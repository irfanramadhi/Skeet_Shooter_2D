﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour
{
    public bool disableGyroTemp = false;
    public float timer;
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;


    // Use this for initialization
    private void Start()
    {

        cameraContainer = new GameObject("MainCamera");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();

    }

    // Update is called once per frame
    void Update()
    {

        if (gyroEnabled && disableGyroTemp == false)
        {
            transform.localRotation = gyro.attitude * rot;
        }
        if(disableGyroTemp)
        {
            timer = 3.0f;
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer < 0 && disableGyroTemp)
        {
            disableGyroTemp = false;
        }
        
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }
        
}
