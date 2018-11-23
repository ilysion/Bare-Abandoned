using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHandler : MonoBehaviour {

    public Terrain terrain;
    public GameObject Barricade1;

    public void buildBarricade1()
    {
        
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(ray, out hitInfo);
        Vector3 buildSpot = hitInfo.point;
        buildSpot.y = GetHeightDetail(terrain.terrainData, Mathf.RoundToInt(buildSpot.z), Mathf.RoundToInt(buildSpot.x));
        
        GameObject barr1 = GameObject.Instantiate(Barricade1);
        barr1.transform.position = buildSpot;
        barr1.transform.Rotate(0, 0, 0, Space.Self);
        

    }

    private float GetHeightDetail(TerrainData terrainData, int x, int y)
    {
        float y_01 = (float)y / (float)terrainData.detailHeight;
        float x_01 = (float)x / (float)terrainData.detailWidth;
        //Gets height at this coordinates
        float height = terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrainData.heightmapWidth), Mathf.RoundToInt(x_01 * terrainData.heightmapWidth));
        return height;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
