using UnityEngine;
using System.Collections;

public class MoveOnAxisInput : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float speed = 5.0f;
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 moveDirection = Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis);
		if(moveDirection.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation(moveDirection,Vector3.up);
		}

		transform.position += moveDirection*speed*Time.deltaTime;
	}
}
