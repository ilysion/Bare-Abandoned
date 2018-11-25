using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScalingAnimation : MonoBehaviour {

    public AnimationCurve animationCurve;
    public float speed;
    public Vector3 startingPosition;
    public Vector3 targetPosition;
    private float timeAggregate;
    public UnityEvent onEndAction;

	// Use this for initialization
	void OnEnable ()
    {
        timeAggregate = 0;
        //transform.position = startingPosition;
        //startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeAggregate += speed * Time.deltaTime;
        float curveSample = animationCurve.Evaluate(timeAggregate);
        Vector3 target = new Vector3(transform.position.x + targetPosition.x, transform.position.y + targetPosition.y, transform.position.z + targetPosition.z);
        transform.position = Vector3.LerpUnclamped(transform.position, targetPosition, curveSample);

        if(timeAggregate >= 1f)
        {
            enabled = false;
            onEndAction.Invoke();
        }
    }
}
