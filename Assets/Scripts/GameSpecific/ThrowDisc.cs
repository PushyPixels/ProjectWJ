using UnityEngine;
using System.Collections;

public class ThrowDisc : MonoBehaviour
{
	public string buttonName = "P1Throw";
	public bool isHoldingDisc = false;
	public Transform handPosition;

	private RigidbodyMoveOnAxisInput basicMovement;
	private bool ignoreNextTrigger = false;

	// Use this for initialization
	void Start ()
	{
		basicMovement = GetComponent<RigidbodyMoveOnAxisInput>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isHoldingDisc && Input.GetButtonDown(buttonName))
		{
			Disc.instance.Throw(transform.forward);
			isHoldingDisc = false;
			basicMovement.enableMovement = true;
			ignoreNextTrigger = true;
		}
	}

	void OnTriggerEnter()
	{
		if(!ignoreNextTrigger)
		{
			basicMovement.enableMovement = false;
			isHoldingDisc = true;
			Disc.instance.Catch(handPosition);
		}
		else
		{
			ignoreNextTrigger = false;
		}
	}
}
