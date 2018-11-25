using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public float AggroRange = 10;
    public float hittingRange = 1;
    public float zombieSpeed;
    

    private Animator animator;
    private SphereCollider collider;
    private GameObject playerGameobject;
    private UIController uicontroller;
    private bool playerInRange;

    private float hitTime;
    private float hitDelay = 1f;

    private float randomWalkTime;
    private float randomWalkDelay = 3f;
    private bool randomWalk;
    


    void Start()
    {
        playerGameobject = GameObject.Find("char_shadow");
        animator = GetComponent<Animator>();
        collider = GetComponent<SphereCollider>();
        collider.radius = AggroRange;
        playerInRange = false;
        randomWalk = false;
        //dno why its not working atm
        //uicontroller = GameObject.Find("canvas").GetComponent<UIController>();
    }


    void Update()
    {
        if (playerInRange)
        {
            rotateZombieToPlayer();
            animator.SetBool("ZWalk", true);
        }
        else
        {
            int randomWalkOrNot = Random.Range(0, 200);
            
            if(randomWalkOrNot < 1)
            {
                randomWalk = true;
                randomWalkTime = 0;
                rotateZombieRandomly();
            }
            //walk randomly
            if (randomWalk)
            {
                
                animator.SetBool("ZWalk", true);
                randomWalkTime += Time.deltaTime;
             
                //time is up
                if (randomWalkTime > randomWalkDelay)
                {
                    randomWalk = false;
                    //sets new time for next random walk
                    randomWalkDelay = Random.Range(2, 6);
                    animator.SetBool("ZWalk", false);

                }
            }
            else
            {
                animator.SetBool("ZWalk", false);
            }
        }

        // using too much resources maybe?
        float dist = Vector3.Distance(playerGameobject.transform.position, transform.position);
        if(dist < hittingRange)
        {
            animator.SetTrigger("ZStartHitting");
            if (hitTime + Time.deltaTime > hitTime + hitDelay)
            {
                //TODO enable when got the controller
                //uicontroller.decreaseHealth(1);
                hitTime = Time.time;
            }
        }
        else
        {
            animator.SetTrigger("ZStopHitting");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("PlayerEnteredRange");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("PlayerExitedRange");
            playerInRange = false;
        }
    }

    private void rotateZombieToPlayer()
    {
        Transform playerPos = playerGameobject.transform;

        Vector3 newZombieDir = Vector3.RotateTowards(transform.forward, playerPos.transform.position, 10, 0.0f);
        transform.rotation = Quaternion.LookRotation(newZombieDir);
        var yRotation = playerPos.transform.eulerAngles.y + 180;

        //transform.Rotate(newZombieDir);
        transform.LookAt(playerPos);
    }

    private void rotateZombieRandomly()
    {
        transform.RotateAround(transform.position, Vector3.up, Random.Range(-180, 180));
    }

    // Deal with the basic player movement
    void MovementManagement(float horizontal, float vertical, bool running)
    {
        // Set proper speed.

    }
}