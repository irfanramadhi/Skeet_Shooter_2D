using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log(cubeBoundaries);
        debugText.text = cubeBoundPosition.y + " ";
        if((cubeBoundPosition.y > 0 && launchPlateStatus == true) || Input.GetMouseButtonDown(0))
        {
            LaunchPlate();
            timerPlate = 3.0f;
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
            Vector3 spawner = new Vector3(0, -5, 0);
            GameObject Plate = Instantiate(prefabPlate) as GameObject;
            Plate.transform.parent = parentGameObject.transform;
            Plate.transform.position = spawner/*transform.localPosition*/ + Camera.main.transform.forward * -5;
            Debug.Log(transform.localPosition);
            Rigidbody rb = Plate.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.up * 60;
            launchPlateStatus = false;
            //timerPlate = 3.0f;
            //tempPlate = platesLeft;
        }
    }
}
