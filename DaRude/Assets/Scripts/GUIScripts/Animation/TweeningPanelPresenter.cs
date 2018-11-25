using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweeningPanelPresenter : MonoBehaviour
{

    public ScalingAnimation OpeningAnimation;
    public ScalingAnimation ClosingAnimation;

    public void Open()
    {
        if(gameObject.activeSelf)
            return;

        gameObject.SetActive(true);
        OpeningAnimation.enabled = true;
    }

    public void Close()
    {
        //TODO Return to the guide. Finish this method after the ScalingAnimation script
        if(!gameObject.activeSelf)
            return;

        ClosingAnimation.enabled = true;
        //gameObject.SetActive(false);
    }

}
