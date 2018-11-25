using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCircle : MonoBehaviour {

    public UIController Canvas;
    GameObject[] players;
    public float narrowingSpeed;
    private float scaledNarrowingSpeed;
    private bool narrowing;
    private int Stage;

    // Use this for initialization
    void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        scaledNarrowingSpeed = narrowingSpeed / 50;
        Stage = 1;
        narrowing = false;

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

        if(Canvas.getNarrowingTime() == 0 && Stage < 6)
        {
            Canvas.NarrowingTime.gameObject.SetActive(false);
            Canvas.NarrowingLabel.gameObject.SetActive(false);
            Canvas.Narrowing.gameObject.SetActive(true);

            //Debug.Log("STAGE: "+Stage + "  ");
            narrowing = true;
            Narrow(Stage);
            if(narrowing == false)
            {
                Canvas.NarrowingTime.gameObject.SetActive(true);
                Canvas.NarrowingLabel.gameObject.SetActive(true);
                Canvas.Narrowing.gameObject.SetActive(false);
                Stage += 1;
                Canvas.setNarrowingTime(NextNarrowingTime(Stage));
            }
        }
        /*if (Input.GetButton("Narrow"))
        {
            Narrow();
        }*/
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

    public void Narrow(int stage)
    {
        int targetScale;

        if(stage == 5)
        {
            targetScale = 5;
            Canvas.setNarrowingText("FINAL STAGE");
        }
        else targetScale = 20 * (5 - stage);

        Vector3 curScale = transform.localScale;
        if (curScale.y > targetScale)
        {
            transform.localScale = new Vector3(curScale.x - scaledNarrowingSpeed, curScale.y - scaledNarrowingSpeed, curScale.z - scaledNarrowingSpeed);
        }
        else narrowing = false;
    }
    
    public int NextNarrowingTime(int stage)
    {
        return 360 - (60 * stage);
    }
}
