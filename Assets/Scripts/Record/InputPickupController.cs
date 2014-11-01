using UnityEngine;
using System.Collections;

public class InputPickupController : MonoBehaviour {
	public bool HoldingObj = false;
	public bool HoldingBaby;
	public GameObject ObjInHand;
	public GameObject CollisionObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			if (HoldingObj ) { // RELEASE
				if (ObjInHand == null) 
					return;

				Rigidbody r = CollisionObj.GetComponent<Rigidbody>();
				if (r != null) r.isKinematic = false;

				ObjInHand.transform.parent = null;
				ObjInHand = null;
				HoldingObj = false;
				HoldingBaby = false;
			} else { // PICK UP
				if (CollisionObj == null) 
					return;

				Rigidbody r = CollisionObj.GetComponent<Rigidbody>();
				if (r != null) r.isKinematic = true;

				CollisionObj.transform.parent = transform.parent.transform;
				ObjInHand = CollisionObj;
				HoldingObj = true;
				if(CollisionObj.tag == "Baby") HoldingBaby = true;
			}
		}
	}
	
	void OnTriggerStay(Collider other) {
		CollisionObj = other.gameObject;
	}
	
	void OnTriggerExit(Collider other) {
		CollisionObj = null;
	}

}
