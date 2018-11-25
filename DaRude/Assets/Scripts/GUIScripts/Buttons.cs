using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Text HintText;

    // Use this for initialization
    void Start()
    {
        HintText.text = "Hints";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "Play")
        {
            HintText.text = "Play In Multiplayer";
        }
        else if (gameObject.name == "Tutorial")
        {
            HintText.text = "Play Through Tutorial Level";
        }
        else if (gameObject.name == "Settings")
        {
            HintText.text = "Adjust Graphics, Audio Settings";
        }
        else if (gameObject.name == "Exit")
        {
            HintText.text = "Quit The Game";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HintText.text = "Hints";
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (gameObject.name == "Play")
            {
                SceneManager.LoadScene("Main");
            }
            else if (gameObject.name == "Tutorial")
            {
                HintText.text = "Clicked on Tutorial";
            }
            else if (gameObject.name == "Settings")
            {
                HintText.text = "Clicked on Settings";
            }
            else if (gameObject.name == "Exit")
            {
                HintText.text = "Clicked on Exit";
            }
        }
    }
}