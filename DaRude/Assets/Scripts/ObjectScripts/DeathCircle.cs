using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCircle : MonoBehaviour {

    GameObject[] players;
    public float narrowingSpeed;
    private float scaledNarrowingSpeed;

    // Use this for initialization
    void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        scaledNarrowingSpeed = narrowingSpeed / 50;

        // Death Wall normals inverting ////////////////////
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;

        Vector3[] normals = mesh.normals;
        for(int i = 0; i < normals.Length; i++)
        {
            normals[i] = -1 * normals[i];
        }

        mesh.normals = normals;

        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tris = mesh.GetTriangles(i);
            for (int j = 0; j < tris.Length; j+=3)
            {
                int temp = tris[j];
                tris[j] = tris[j + 1];
                tris[j + 1] = temp;
            }
            mesh.SetTriangles(tris, i);
        }
        // Death Wall normals inverting ////////////////////
    }

    // Update is called once per frame
    void Update ()
    {
        foreach(GameObject player in players)
        {
            CapsuleCollider playerCollider = player.GetComponent<CapsuleCollider>();
        }

        if (Input.GetButton("Narrow"))
        {
            Vector3 curScale = this.transform.localScale;
            if (curScale.y > 5)
            {
                this.transform.localScale = new Vector3(curScale.x - scaledNarrowingSpeed, curScale.y - scaledNarrowingSpeed, curScale.z - scaledNarrowingSpeed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().setOutOfDeathCircle(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().setOutOfDeathCircle(true);
        }
    }
}
