using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour {

    public float speed = 10.0f;
    public bool limitMove = true;

    private Vector2 minPosition, maxPosition;

    // Use this for initialization
    void Start ()
    {
        minPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (limitMove)
        {
            Vector2 dir = Vector2.zero;
            dir.x = Input.acceleration.x;
            dir.y = -Input.acceleration.z;

            if (dir.sqrMagnitude > 1)
                dir.Normalize();
            dir *= Time.deltaTime;
            transform.Translate(dir * speed);
        }
	}

    public void MoveUp()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position + Vector2.up * speed * Time.deltaTime;
            if (newPosition.y < maxPosition.y)
            {
                this.transform.position = newPosition;
            }
        }
        else
        {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    public void MoveDown()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position -
                Vector2.up * speed * Time.deltaTime;
            if (newPosition.y > minPosition.y)
            {
                this.transform.position = newPosition;
            }
        }
    }
    public void MoveLeft()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position -
                Vector2.right * speed * Time.deltaTime;
            if (newPosition.x > minPosition.x)
            {
                this.transform.position = newPosition;
            }
        }
    }
    public void MoveRight()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position +
                Vector2.right * speed * Time.deltaTime;
            if (newPosition.x < maxPosition.x)
            {
                this.transform.position = newPosition;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
    }
}
