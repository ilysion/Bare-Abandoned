using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Itemi item;
    public Text QuantityText;
    public Image SlotImage;
    public Sprite DefaultSprite;
	// Use this for initialization
	void Start ()
    {
        if (item != null)
        {
            if (!item.Stackable)
            {
                QuantityText.text = "";
            }
            else
            {
                QuantityText.text = item.Quantity + "x";
            }
            SlotImage.sprite = item.Sprite;
        }
        else
        {
            QuantityText.text = "";
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if(item != null && item.Quantity == 0)
        {
            DropItem();
        }
	}

    public void DropItem()
    {
        item = null;
        SlotImage.sprite = null;
        QuantityText.text = "";
    }

    public void increaseQuantity(int amount)
    {
        if (item.Stackable)
        {
            item.Quantity += amount;
            QuantityText.text = item.Quantity + "x";
        }

    }
    public void decreaseQuantity(int amount)
    {
        if (item.Stackable)
        {
            item.Quantity -= amount;
            QuantityText.text = item.Quantity + "x";
        }
    }
}
