using UnityEngine;
using System.Collections;

public class ThrowDisc : MonoBehaviour
{
	public string buttonName = "P1Throw";
	public float reCatchDelay = 0.5f;
	public Transform handPosition;

	public bool isHoldingDisc { get; private set; }

	private RigidbodyMoveOnAxisInput basicMovement;
	private Slide slideMovement;
	private bool ignoreTriggers = false;

	// Use this for initialization
	void Start ()
	{
		basicMovement = GetComponent<RigidbodyMoveOnAxisInput>();
		slideMovement = GetComponent<Slide>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isHoldingDisc && Input.GetButtonDown(buttonName) && !slideMovement.isSliding)
		{
			Disc.instance.Throw(transform.forward);
			isHoldingDisc = false;
			basicMovement.enableMovement = true;
			ignoreTriggers = true;
			Invoke("ResetIgnoreTriggers",reCatchDelay);
		}
	}

	void ResetIgnoreTriggers()
	{
		ignoreTriggers = false;
	}

	void OnTriggerEnter()
	{
		if(!ignoreTriggers)
		{
			basicMovement.enableMovement = false;
			isHoldingDisc = true;
			Disc.instance.Catch(handPosition);
		}
	}
}
