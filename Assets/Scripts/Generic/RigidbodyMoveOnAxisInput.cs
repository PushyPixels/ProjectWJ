using UnityEngine;
using System.Collections;

public class RigidbodyMoveOnAxisInput : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float speed = 5.0f;
	public bool normalizeMovement = true;

	public bool isMoving { get; private set; }

	new private Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 moveDirection = Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis);
		if(moveDirection.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation(moveDirection,Vector3.up);
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

		rigidbody.MovePosition(transform.position+moveDirection*speed*Time.deltaTime);
		rigidbody.velocity = Vector3.zero;
	}
}
