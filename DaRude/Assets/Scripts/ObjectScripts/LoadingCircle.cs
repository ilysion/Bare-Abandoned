using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCircle : MonoBehaviour {

    public float loadingTime; //secconds for loading
    private float fill;
	// Use this for initialization
	void Start () {
        fill = 1f;
        loadingTime = 3f; 
        gameObject.GetComponent<Image>().fillAmount = fill;

    }
	
	// Update is called once per frame
	void Update () {
        fill -= Time.deltaTime * (1/loadingTime);
        gameObject.GetComponent<Image>().fillAmount = fill;
        
    }

    public void ResetLoading()
    {
        fill = 1f;
    }
}
