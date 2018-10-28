using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarTool : MonoBehaviour {

    private string ToolName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetToolName(string str)
    {
        this.ToolName = str;
    }

    public string GetToolName()
    {
        return ToolName;
    }
}
