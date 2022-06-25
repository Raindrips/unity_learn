using System.Collections;
using UnityEngine;

    public class DestoryByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}