using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarHandler : MonoBehaviour {

    //tool images;
    public Sprite HatchetSprite;
    public Sprite PickaxeSprite;
    //Tool Gameobjects
    public GameObject Hatchet;
    public GameObject Pickaxe;
    private List<GameObject> ToolsList;

    public GameObject BarButtonPrefab;

    private Button Tool1;
    private List<GameObject> Buttons;

    private Button ActiveButton;
    

	// Use this for initialization
	void Start () {

        Buttons = new List<GameObject>();
        ToolsList = new List<GameObject>();

        ToolsList.Add(Hatchet);
        ToolsList.Add(Pickaxe);

        //making all buttons manually atm
        GameObject newButton = Instantiate(BarButtonPrefab);
        newButton.transform.SetParent(gameObject.transform, false);
        newButton.GetComponent<Image>().sprite = HatchetSprite;
        newButton.GetComponent<ToolbarTool>().SetToolName("Hatchet");
        newButton.GetComponentInChildren<Text>().text = "Hatchet";
        Buttons.Add(newButton);

        GameObject newButton2 = Instantiate(BarButtonPrefab);
        newButton2.transform.SetParent(gameObject.transform, false);
        newButton2.GetComponent<Image>().sprite = PickaxeSprite;
        newButton2.GetComponent<ToolbarTool>().SetToolName("Pickaxe");
        newButton2.GetComponentInChildren<Text>().text = "Pickaxe";
        Buttons.Add(newButton2);

        //makes 6 random buttons that do nothing atm ---------------------------------------------------------
        for (int i = 0; i < 5; i++)
        {
            GameObject EmptyButton = Instantiate(BarButtonPrefab);
            EmptyButton.transform.SetParent(gameObject.transform, false);
            EmptyButton.GetComponent<ToolbarTool>().SetToolName("button" + i);
            EmptyButton.GetComponentInChildren<Text>().text = "button" + i;
            Buttons.Add(EmptyButton);
        }

        foreach (GameObject buttonObject in Buttons)
        {
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => GetTool(button));
        }
        //also set the first button in list to be active at start;
        ActiveButton = Buttons[0].GetComponent<Button>();
        //and also make the first button to really be active for the button script;
        ActiveButton.GetComponent<Button>().Select();
        GetTool(ActiveButton);

    }

   

    // Update is called once per frame
    void Update () {

	}

    public string getActiveToolName()
    {
        return ActiveButton.GetComponent<ToolbarTool>().GetToolName();
    }

    private void GetTool(Button button)
    {
        //Deactivate all tools
        foreach (GameObject tool in ToolsList)
        {
            tool.SetActive(false);
        }

        ActiveButton = button;
        print("active tool: " + button.GetComponent<ToolbarTool>().GetToolName());
        
        if (button.GetComponent<ToolbarTool>().GetToolName() == "Hatchet")
        {
            Hatchet.SetActive(true);
        }
        else if (button.GetComponent<ToolbarTool>().GetToolName() == "Pickaxe")
        {
            Pickaxe.SetActive(true);
        }

    }


    private void ToolHatchet()
    {
        Hatchet.SetActive(true);
    }

    private void ToolPickaxe()
    {
        Pickaxe.SetActive(true);
    }
}
