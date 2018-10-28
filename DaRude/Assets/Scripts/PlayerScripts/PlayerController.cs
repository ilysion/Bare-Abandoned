using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    public UIController Canvas;
    public int Health;
    private bool OutOfDeathCircle;
    private float curTimeStamp;
    private float WLTimeStamp;
    public float harmDelay;
    public int circleHarmAmount;
    private float sceneRestartDelay;

    // Use this for initialization
    void Start ()
    {
        OutOfDeathCircle = false;
        Health = 100;
        curTimeStamp = Time.time;
        sceneRestartDelay = 4;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (OutOfDeathCircle && Time.time > curTimeStamp + harmDelay)
        {
            decreaseHealth(circleHarmAmount);
            curTimeStamp = Time.time;
        }

        if(Health <= 0)
        {
            if(Canvas.MainPanel.activeInHierarchy != true)
            {
                Canvas.Lost();
                WLTimeStamp = Time.time;
            }
        }

        // For test
        if (Input.GetButton("Win"))
        {
            Canvas.Win();
            WLTimeStamp = Time.time;
        }

        if (WLTimeStamp != 0 && Time.time > WLTimeStamp + sceneRestartDelay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void decreaseHealth(int amount)
    {
        this.Health -= amount;
        Canvas.decreaseHealth(amount);
    }

    public void setOutOfDeathCircle(bool state)
    {
        this.OutOfDeathCircle = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TreeTag"))
        {
            //hit small three
            
        }
    }
}
