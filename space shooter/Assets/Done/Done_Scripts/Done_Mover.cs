using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		var rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity = transform.forward * speed;
	}
}
