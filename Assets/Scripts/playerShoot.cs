using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

	public float maxShootDistnace = 25f;
	public float shootForce = 100f;
	Camera cam;

	void Awake()
	{
		cam = transform.GetComponentInChildren<Camera>();
	}

	void FixedUpdate()
	{
		RaycastHit hit;
		Vector3 origin = cam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
		if(Physics.Raycast(origin, cam.transform.forward, out hit, maxShootDistnace) && Input.GetMouseButtonDown(1))
		{
			print("we hit a thing");
			print("SHOOT IT");
			print(hit.normal);
			print(hit.point);
			hit.rigidbody.AddForce (-hit.normal * shootForce);
		}

	}
}
