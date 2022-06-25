using UnityEngine;

public class Done_RandomRotator : MonoBehaviour 
{
	public float tumble;
	
	void Start ()
	{
		var rigidbody = GetComponent<Rigidbody>();
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	} 
}