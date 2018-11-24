using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialHandler : MonoBehaviour {
  

    GameObject materialsPanel;
    Text textWood, textStone;
    private int woodAmmount;
    private int stoneAmmount;

    public int startingWood = 0;
    public int startingStone = 0;

	// Use this for initialization
	void Start () {
        materialsPanel = GameObject.Find("InfoPanel");
        textWood = GameObject.Find("WoodAmmountText").GetComponent<Text>();
        textStone = GameObject.Find("StoneAmmountText").GetComponent<Text>();
        woodAmmount = startingWood;
        stoneAmmount = startingStone;
        updateTexts();


    }

    //if not enough resources, returns -1, else 0
    public int removeResources(int woodToRemove, int stoneToRemove)
    {
        if(woodAmmount >= woodToRemove && stoneAmmount >= stoneToRemove)
        {
            woodAmmount -= woodToRemove;
            stoneAmmount = stoneToRemove;
            updateTexts();
            return 0;
        }

        else
        {
            return -1;
        }
    }

    public void updateTexts()
    {
        textWood.text = "Wood: " + woodAmmount;
        textStone.text = "Stone: " + stoneAmmount;
    }

    public void addWood(int a)
    {
        woodAmmount += a;
        textWood.text = "Wood: " + woodAmmount;
        print("woodaaded");
    }

    public void addStone(int a)
    {
        stoneAmmount += a;
        textStone.text = "Stone: " + stoneAmmount;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
