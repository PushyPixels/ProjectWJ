using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Disc : MonoBehaviour 
{
	public static Disc instance;

	public float speed = 10.0f;

	new private Rigidbody rigidbody;

	void Awake()
	{
		instance = this;
	}
	
	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void Throw(Vector3 direction)
	{
		transform.parent = null;
		rigidbody.isKinematic = false;
		rigidbody.velocity = direction*speed;
	}

	public void Catch(Transform catcher)
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.isKinematic = true;
		transform.parent = catcher;
		transform.localPosition = Vector3.zero;
	}
}
