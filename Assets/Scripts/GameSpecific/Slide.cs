using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour
{
	public string buttonName = "P1Throw";
	public float slideSpeed = 10.0f;
	public float slideTime = 1.0f;
	public AnimationCurve slideCurve;

	public bool isSliding { get; private set; }
	new private Rigidbody rigidbody;
	private RigidbodyMoveOnAxisInput basicMovement;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		basicMovement = GetComponent<RigidbodyMoveOnAxisInput>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(buttonName) && !isSliding && basicMovement.isMoving)
		{
			StartCoroutine(SlideNow());
		}
	}

	IEnumerator SlideNow()
	{
		isSliding = true;
		basicMovement.enabled = false;

		float t = 0.0f;

		while(t <= slideTime)
		{
			t += Time.deltaTime;
			float currentSlideSpeed = slideCurve.Evaluate(t/slideTime)*slideSpeed;
			rigidbody.MovePosition(transform.position+transform.forward*currentSlideSpeed*Time.deltaTime);
			rigidbody.velocity = Vector3.zero;
			yield return null;
		}

		basicMovement.enabled = true;
		isSliding = false;
	}
}
