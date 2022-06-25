using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotaion : MonoBehaviour {
	public float tumble;

	void Start() {
		var rigidbody = GetComponent<Rigidbody>();
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}

}
