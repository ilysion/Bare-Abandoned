using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    private GameObject[] Slots;
    private GameObject[] HandSlots;
    //public Stats Stats;

	// Use this for initialization
	void Start()
    {
        Slots = GameObject.FindGameObjectsWithTag("Slot");
        HandSlots = GameObject.FindGameObjectsWithTag("Hand Slot");
        //Stats.setTotalWeight(getTotalWeight());
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("Wood: " + Contains("Wood"));
        //Debug.Log("Wood Amount: " + getItem("Wood").item.Quantity);
    }

    public bool Contains(string name)
    {
        foreach(GameObject slot in Slots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item != null && s.item.Name == name)
            {
                return true;
            }
        }
        foreach (GameObject slot in HandSlots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item != null && s.item.Name == name)
            {
                return true;
            }
        }
        return false;
    }

    public int getFreeSlots()
    {
        int amount = 0;

        foreach (GameObject slot in Slots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item == null)
                amount++;
        }
        return amount;
    }

    public void putItem(Item item)
    {
        foreach (GameObject slot in Slots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item == null)
            {
                s.item = item;
                break;
            }
        }
    }

    public Slot getItem(string name)
    {
        foreach (GameObject slot in Slots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item != null && s.item.Name == name)
            {
                return s;
            }
        }
        foreach (GameObject slot in HandSlots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item != null && s.item.Name == name)
            {
                return s;
            }
        }
        return null;
    }

    public float getTotalWeight()
    {
        Slots = GameObject.FindGameObjectsWithTag("Slot");
        HandSlots = GameObject.FindGameObjectsWithTag("Hand Slot");
        float weight = 0;

        foreach (GameObject slot in Slots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item != null)
            {
                weight += s.item.Weight * s.item.Quantity;
            }
        }
        foreach (GameObject slot in HandSlots)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s.item != null)
            {
                weight += s.item.Weight * s.item.Quantity;
            }
        }
        return weight;
    }
}
