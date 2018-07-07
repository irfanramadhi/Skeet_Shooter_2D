using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    
    public Text debugText;
    public Vector3 cubeBoundPosition;

    public Text scoreText;
    public Text bulletsLeftText;
    public Text platesLeftText;
    public int platesLeft;
    public int bulletsLeft;
    public int currentScore;

    private int tempPlate;
    private float timer = 0;
    private float timerPlate = 0;

    private bool launchPlateStatus;

    public GameObject cameraGyro;
    public GameObject parentGameObject;
    public GameObject launchPad;
    public GameObject prefabPlate;
    public GameObject shootButton;
    public GameObject cubeBoundaries;
    public GameObject bulletIndicator;

    // Use this for initialization
    void Start ()
    {
        launchPlateStatus = true;
        bulletsLeft = 10;
        platesLeft = 5;
        currentScore = 0;
        prefabPlate = Resources.Load("Plate") as GameObject;

	}
	
	// Update is called once per frame
	void Update ()
    {
        cubeBoundPosition = cubeBoundaries.transform.position;
        debugText.text = cubeBoundPosition.y + " ";
        if((cubeBoundPosition.y > 0 && launchPlateStatus == true) || Input.GetMouseButtonDown(0))
        {
            LaunchPlate();
            timerPlate = 5.0f;
            tempPlate = platesLeft;
        }
        if(timerPlate > 0)
        {
            timerPlate -= Time.deltaTime;
        }
        if(timerPlate < 0)
        {
            launchPlateStatus = true;
        }
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer < 0)
        {
            shootButton.SetActive(true);
            bulletIndicator.SetActive(false);
        }
        platesLeftText.text = platesLeft + "/5";
        bulletsLeftText.text = bulletsLeft + "";
        scoreText.text = "Score\t : " + currentScore;

    }

    public void Shooting()
    {
        if(bulletsLeft > 0)
        {
            bulletsLeft--;
            shootButton.SetActive(false);
            timer = 0.5f;
            bulletIndicator.SetActive(true);
        }
    }

    public void LaunchPlate()
    {
        if(platesLeft > 0 && launchPlateStatus == true)
        {
            platesLeft--;
            
            GameObject Plate = Instantiate(prefabPlate) as GameObject;
            Plate.transform.parent = parentGameObject.transform;
            Vector3 spawner = new Vector3((transform.localPosition.x - Random.Range(-6, 6)), transform.localPosition.y, transform.localPosition.z);
            Plate.transform.position = spawner + Camera.main.transform.forward * -5;
            Rigidbody rb = Plate.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.up * 40;
            launchPlateStatus = false;
            GyroControl disableGyro = cameraGyro.GetComponent<GyroControl>();
            disableGyro.disableGyroTemp = true;
            
            //timerPlate = 3.0f;
            //tempPlate = platesLeft;
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Main Gameplay");
    }
}
