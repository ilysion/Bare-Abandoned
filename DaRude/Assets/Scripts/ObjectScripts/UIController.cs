using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject Inventory;
    public GameObject InventoryStats;
    public GameObject Skills;
    public Text Position;
    public Text NarrowingTime;
    public Text NarrowingLabel;
    public Text Narrowing;
    GameObject winText;
    GameObject looseText;
    public GameObject healthBar;
    GameObject healthBarFG;
    private float timeStamp;
    private GameObject[] HandSlots;
    private GameObject[] Slots;

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
        timeStamp = Time.time;
        setPosition(25);
        setNarrowingTime(360);
        HandSlots = GameObject.FindGameObjectsWithTag("Hand Slot");
        Slots = GameObject.FindGameObjectsWithTag("Slot");
        //Debug.Log("Hand Slots: " + HandSlots.Length);
        //Debug.Log("Slots: " + Slots.Length);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (getNarrowingTime() > 0 && Time.time > timeStamp + 1)
        {
            timeStamp = Time.time;
            setNarrowingTime(getNarrowingTime()-1);
        }

        if(getNarrowingTime() == 0)
        {
            NarrowingTime.gameObject.SetActive(false);
            NarrowingLabel.gameObject.SetActive(false);
            Narrowing.gameObject.SetActive(true);
        }
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

    public void toggleInventory()
    {
        if (Inventory.activeSelf == false)
        {
            Inventory.SetActive(true);
            ThirdPersonOrbitCam tpoc = Camera.main.GetComponent<ThirdPersonOrbitCam>();
            tpoc.enabled = false;
        }
        else
        {
            Inventory.SetActive(false);
            ThirdPersonOrbitCam tpoc = Camera.main.GetComponent<ThirdPersonOrbitCam>();
            tpoc.enabled = true;
        }
    }

    public void toggleSkills()
    {
        TweeningPanelPresenter tpp = Skills.GetComponent<TweeningPanelPresenter>();
        if (Skills.activeSelf == false)
        {
            tpp.Open();
        }
        else if (Skills.activeSelf == true)
        {
            tpp.Close();
        }
    }

    public void setPosition(int pos)
    {
        Position.text = pos.ToString();
    }
    public int getPosition()
    {
        return int.Parse(Position.text);
    }

    public void setNarrowingTime(int time)
    {
        NarrowingTime.text = time + "s";
    }
    public int getNarrowingTime()
    {
        return int.Parse(NarrowingTime.text.Substring(0, NarrowingTime.text.Length-1));
    }

    public void setNarrowingText(string text)
    {
        Narrowing.text = text;
    }
}
