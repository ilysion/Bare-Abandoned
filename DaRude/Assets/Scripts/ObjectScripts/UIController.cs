using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public GameObject MainPanel;
    GameObject winText;
    GameObject looseText;
    public GameObject healthBar;
    GameObject healthBarFG;

    // Use this for initialization
    void Start ()
    {
        //MainPanel = gameObject.transform.Find("Panel").gameObject;
        winText = MainPanel.transform.Find("Win").gameObject;
        looseText = MainPanel.transform.Find("Lost").gameObject;
        //healthBar = MainPanel.transform.Find("Health Bar").gameObject;
        healthBarFG = healthBar.transform.Find("foreground").gameObject;
        MainPanel.SetActive(false);
        winText.SetActive(false);
        looseText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Lost()
    {
        MainPanel.SetActive(true);
        looseText.SetActive(true);
    }

    public void Win()
    {
        MainPanel.SetActive(true);
        winText.SetActive(true);
    }

    public void decreaseHealth(int amount)
    {
        healthBarFG.GetComponent<Image>().fillAmount -= amount/100f;
    }
}
