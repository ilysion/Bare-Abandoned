using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// AimBehaviour inherits from GenericBehaviour. This class corresponds to aim and strafe behaviour.
public class AimBehaviour : GenericBehaviour
{
    public Text annoucementText;
    public GameObject LoadingBar;
    public GameObject Toolbar;
    public GameObject MainCanvas;
	public Texture2D crosshair;                                           // Crosshair texture.
	public float aimTurnSmoothing = 15.0f;                                // Speed of turn response when aiming to match camera facing.
	public Vector3 aimPivotOffset = new Vector3(0.0f, 1.7f,  -0.3f);      // Offset to repoint the camera when aiming.
	public Vector3 aimCamOffset   = new Vector3(0.8f, 0.0f, -1.0f);       // Offset to relocate the camera when aiming.

	private int aimBool;                                                  // Animator variable related to aiming.
	private bool aim;                                                     // Boolean to determine whether or not the player is aiming.
    private float ChopStartTime;
    private float AnnoucementTextTime;
    private bool AnnoucementTextActive;


    // Start is always called after any Awake functions.
    void Start ()
	{
        ChopStartTime = 0;
        AnnoucementTextTime = 0;
		// Set up the references.
		aimBool = Animator.StringToHash("Aim");

		// Subscribe this behaviour on the manager.
		behaviourManager.SubscribeBehaviour (this);
	}

	// Update is used to set features regardless the active behaviour.
	void Update ()
	{
		// Activate aim by input.
		aim = Input.GetButton("Aim");

		// Player is aiming.
		if (aim)
		{
			// Register this behaviour.
			behaviourManager.RegisterBehaviour (this.behaviourCode);
		}
		// Player just stopped aiming.
		else if(behaviourManager.IsCurrentBehaviour(this.behaviourCode))
		{
			// Ensure the camera will be back to original setup when is not aiming.
			camScript.ResetTargetOffsets ();
			camScript.ResetMaxVerticalAngle ();

			// Unregister this behaviour and set current behaviour to the default one.
			behaviourManager.UnregisterBehaviour (this.behaviourCode);
		}

		canSprint = !aim;

		// Toggle camera aim position left or right.
		if (aim && Input.GetButtonDown ("Fire3"))
		{
			aimCamOffset.x = aimCamOffset.x * (-1);
            
		}

		// Set aim boolean on the Animator Controller.
		anim.SetBool (aimBool, aim);

        if (Input.GetMouseButton(0))
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(ray, out hitInfo);
            if (hit)
            {
                print("hit something:" + hitInfo.transform.gameObject.tag);
                
                if (hitInfo.transform.gameObject.tag == "TreeTag")
                {
                    //Ray hit tree
                    if (Toolbar.GetComponent<ToolbarHandler>().getActiveToolName() == "Hatchet")
                    {
                        ChopTree();
                    }
                }
                
            }

        }
        else //means mouse not pressed
        {
            LoadingBar.SetActive(false);

        }
        if (AnnoucementTextActive)
        {
            AnnoucementTextTime += Time.deltaTime;
        }

        if (AnnoucementTextTime > 2)
        {
            annoucementText.text = "";
            AnnoucementTextActive = false;
            AnnoucementTextTime = 0;
        }
    }

    private void ChopTree()
    {
        if(LoadingBar.active == false)
        {
            LoadingBar.GetComponent<LoadingCircle>().ResetLoading();
            ChopStartTime = 0;
        }
        LoadingBar.SetActive(true);
        ChopStartTime += Time.deltaTime;

        if(ChopStartTime > 3)
        {
            annoucementText.text = "You chopped 3 logs";
            AnnoucementTextActive = true;
            LoadingBar.SetActive(false);
            ChopStartTime = 0;
        }

        
        
    }

	// LocalFixedUpdate overrides the virtual function of the base class.
	public override void LocalFixedUpdate()
	{
		// Set camera position and orientation to the aim mode parameters.
		camScript.SetTargetOffsets (aimPivotOffset, aimCamOffset);

		// Call the aim manager.
		AimManagement ();
	}

	// Deal with the player movement when aiming.
	void AimManagement()
	{
		Rotating();
	}

	// Rotate the player to match correct orientation, according to camera.
	void Rotating()
	{
		Vector3 forward = behaviourManager.playerCamera.TransformDirection(Vector3.forward);
		// Player is moving on ground, Y component of camera facing is not relevant.
		forward.y = 0.0f;
		forward = forward.normalized;

		// Always rotates the player according to the camera forward in aim mode.
		Quaternion targetRotation = Quaternion.LookRotation (forward);

		Quaternion newRotation = Quaternion.Slerp(rbody.rotation, targetRotation, aimTurnSmoothing * Time.deltaTime);
		rbody.MoveRotation (newRotation);
		behaviourManager.SetLastDirection(forward);
	}

 	// Draw the crosshair when on aim mode.
	void OnGUI () 
	{
		float mag = camScript.getCurrentPivotMagnitude (aimPivotOffset);
        //if (mag < 0.05f) //draws crosshair when in aim mode
        if (true)
            GUI.DrawTexture(new Rect(Screen.width/2-(crosshair.width*0.5f), 
			                         Screen.height/2-(crosshair.height*0.5f), 
			                         crosshair.width, crosshair.height), crosshair);
	}
}
