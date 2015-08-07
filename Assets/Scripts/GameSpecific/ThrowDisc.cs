using UnityEngine;
using System.Collections;

public class ThrowDisc : MonoBehaviour
{
	public string buttonName = "P1Throw";
	public bool holdingDisc = false;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(buttonName))
		{

		}
	}
}
