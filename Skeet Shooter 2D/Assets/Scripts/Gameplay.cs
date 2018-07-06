using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public Text scoreText;
    public int currentScore = 0;
    public GameObject cubeBoundaries;

    // Use this for initialization
    void Start ()
    {
		
        

	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score\t : " + currentScore;
    }
}
