using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHandler : MonoBehaviour {

    public Terrain terrain;
    public GameObject Barricade1;

    private MaterialHandler materialHandler;
    private Inventory PlayerInventory;
    private Skills PlayerSkills;


    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        PlayerInventory = canvas.GetComponent<Inventory>();
        materialHandler = canvas.GetComponent<MaterialHandler>();
        PlayerSkills = canvas.GetComponent<Skills>();
    }

    public void buildBarricade1()
    {
        //if(materialHandler.removeResources(25, 0) == 0)
        if (PlayerInventory.getItem("Wood").item.Quantity >= 25)
        {
            PlayerInventory.getItem("Wood").decreaseQuantity(25);
            PlayerSkills.setCraftingExp(PlayerSkills.getCraftingExp() + 5);
            //was enough resources, continue with building
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(ray, out hitInfo);
            Vector3 buildSpot = hitInfo.point;
            buildSpot.y = GetHeightDetail(terrain.terrainData, Mathf.RoundToInt(buildSpot.z), Mathf.RoundToInt(buildSpot.x));
            GameObject barr1 = GameObject.Instantiate(Barricade1);
            barr1.transform.position = buildSpot;
            print(Camera.main.transform.rotation.eulerAngles);
            barr1.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y - 90, 0);
        }
        else
        {
            print("Not enoguht resources");
        }
        

    }

    private float GetHeightDetail(TerrainData terrainData, int x, int y)
    {
        float y_01 = (float)y / (float)terrainData.detailHeight;
        float x_01 = (float)x / (float)terrainData.detailWidth;
        //Gets height at this coordinates
        float height = terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrainData.heightmapWidth), Mathf.RoundToInt(x_01 * terrainData.heightmapWidth));
        return height;
    }


}
