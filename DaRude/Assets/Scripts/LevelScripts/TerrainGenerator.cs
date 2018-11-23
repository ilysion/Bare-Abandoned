using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TerrainGenerator : MonoBehaviour
{

    public int width = 1024;
    public int height = 1024;
    public int depth = 20;
    public float scale = 20f;

    public float offsetX = 1000f;
    public float offsetY = 1000f;

    public GameObject TreeMediumPrefab;
    public GameObject TreeSmallPrefab;

    private List<GameObject> TreesList;

    void Start()
    {
        TreesList = new List<GameObject>();
        // takes random offset so every time the map is different
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        GenerateTrees(terrain.terrainData);
        
    }
    

    private void GenerateTrees(TerrainData terraindata)
    {
        Vector3 position = new Vector3(0, 0, 0);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int PlaceRandom1 = Random.Range(1, 400);
                int PlaceRandom2 = Random.Range(1, 200);
                if (PlaceRandom1 < 2)
                {
                    position.x = x;
                    position.z = y;
                    position.y = GetHeightDetail(terraindata, Mathf.RoundToInt(position.z), Mathf.RoundToInt(position.x));
                    GameObject mytree = GameObject.Instantiate(TreeSmallPrefab);
                    mytree.transform.position = position;
                    TreesList.Add(mytree);           
                }

                if (PlaceRandom2 < 2)
                {
                    position.x = x;
                    position.z = y;
                    position.y = GetHeightDetail(terraindata, Mathf.RoundToInt(position.z), Mathf.RoundToInt(position.x));
                    GameObject mytree = GameObject.Instantiate(TreeMediumPrefab);
                    mytree.transform.position = position;
                    TreesList.Add(mytree);
                }
            }

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
    

    //Generates Terrain land
    TerrainData GenerateTerrain(TerrainData terraindata)
    {
        terraindata.heightmapResolution = width + 1;
        terraindata.size = new Vector3(width, depth, height);
        terraindata.SetHeights(0, 0, GenerateHeights());
        return terraindata;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }

        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
