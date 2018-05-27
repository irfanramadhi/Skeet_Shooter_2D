using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour
{
    public Text gyroText;

    public float gyroXhandler;
    public float gyroYhandler;
    public float gyroZhandler;
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;


    // Use this for initialization
    private void Start()
    {

        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();

    }

    // Update is called once per frame
    void Update()
    {

        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
            gyroXhandler = transform.localRotation.eulerAngles.x;
            gyroYhandler = transform.localRotation.eulerAngles.y;
            gyroZhandler = transform.localRotation.eulerAngles.z;
            gyroText.text = (gyroXhandler.ToString()) + "\n" + (gyroYhandler.ToString()) + "\n" + (gyroZhandler.ToString());
            Debug.Log(gyroText.text);
        }

    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    public void SetGyro()
    {
        //gyroText.text = transform.localRotation.ToString;
    }

}
