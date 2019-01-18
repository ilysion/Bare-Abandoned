using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    private int Health;
    private float Weight;
    private float MaxWeight;
    private Inventoryi PlayerInventory;
    public GameObject Canvas;
    public Text HealthPercent;
    public Text TotalWeight;
    public Text MaxWeightText;
    // Use this for initialization
    void Start()
    {
        PlayerInventory = Canvas.GetComponent<Inventoryi>();
        MaxWeight = 100;
        setMaxWeight(100);
        Health = 100;
        setHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        Weight = PlayerInventory.getTotalWeight();
        setTotalWeight(Weight);
    }

    public void setTotalWeight(float weight)
    {
        Weight = weight;
        TotalWeight.text = weight.ToString() + "kg";
    }

    public void setMaxWeight(float weight)
    {
        MaxWeight = weight;
        MaxWeightText.text = weight.ToString() + "kg";
    }

    public void setHealth(int percent)
    {
        Health = percent;
        HealthPercent.text = percent + "%";
    }
}
