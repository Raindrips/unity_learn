using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
	public float speed;

	void Start() {
		var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody) {
			rigidbody.velocity = transform.forward * speed;
		}
	
	}
}
