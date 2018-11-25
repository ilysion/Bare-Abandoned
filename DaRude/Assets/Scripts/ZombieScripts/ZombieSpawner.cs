using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject ZombiePrefab1;
    public int spawnRangeFromPlayer = 100;
    public int zombiesToSpawn = 10;
    GameObject terrain;

    private int width, height;
    private List<GameObject> ZombieList;

    // Use this for initialization
    void Start () {
        ZombieList = new List<GameObject>();
        terrain = GameObject.Find("Terrain");
        width = terrain.GetComponent<TerrainGenerator>().width;
        height = terrain.GetComponent<TerrainGenerator>().height;

        SpawnZombies(terrain.GetComponent<Terrain>().terrainData);

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void SpawnZombies(TerrainData terraindata)
    {
        Vector3 position = new Vector3(0, 0, 0);
        Transform playerTrans = transform;

        for (int x = 0; x < zombiesToSpawn; x++)
        {
            position.x = Random.Range(playerTrans.transform.position.x - spawnRangeFromPlayer, playerTrans.transform.position.x + spawnRangeFromPlayer);
            position.z = Random.Range(playerTrans.transform.position.z - spawnRangeFromPlayer, playerTrans.transform.position.z + spawnRangeFromPlayer);
            position.y = GetHeightDetail(terraindata, Mathf.RoundToInt(position.z), Mathf.RoundToInt(position.x));
            GameObject zombie1 = GameObject.Instantiate(ZombiePrefab1);
            zombie1.transform.position = position;
            ZombieList.Add(zombie1);

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
