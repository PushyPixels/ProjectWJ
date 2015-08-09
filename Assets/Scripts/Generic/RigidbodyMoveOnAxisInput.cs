using UnityEngine;
using System.Collections;

public class RigidbodyMoveOnAxisInput : MonoBehaviour
{
	public string horizontalAxis = "P1Horizontal";
	public string verticalAxis = "P1Vertical";
	public float speed = 5.0f;
	public bool normalizeMovement = true;
	public bool enableMovement = true;
	public bool enableRotation = true;

	public bool isMoving { get; private set; }
	public Vector3 moveDirection { get; private set; }

	new private Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		moveDirection = Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis);

		if(moveDirection.sqrMagnitude > 0.0f)
		{
			if(enableRotation)
			{
				transform.rotation = Quaternion.LookRotation(moveDirection,Vector3.up);
			}
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}

		if(normalizeMovement)
		{
			moveDirection.Normalize();
		}

		if(enableMovement)
		{
			rigidbody.MovePosition(transform.position+moveDirection*speed*Time.deltaTime);
		}
		else
		{
			isMoving = false;
		}

		rigidbody.velocity = Vector3.zero;
	}
}
