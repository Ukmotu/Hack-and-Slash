using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform myTransform;
	public Transform target;
	public int movementspeed;
	public int rotationspeed;
	public int maxDistance;

	void Awake() {
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);

		//Look at Target
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationspeed * Time.deltaTime);
		//Move Towards Target
		if (Vector3.Distance (target.position, transform.position) > maxDistance) {
			myTransform.position += myTransform.forward * movementspeed * Time.deltaTime;
		}
	}
}
