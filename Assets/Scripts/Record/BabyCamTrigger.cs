using UnityEngine;
using System.Collections;

public class BabyCamTrigger : MonoBehaviour {
	public int MyID;
	private BabyCamController _controller;
	
	void Awake() {
		_controller = GameObject.Find("Global").GetComponent<BabyCamController>();
	}

	void Start(){
		// get the instance ID of the camera
		Camera cam;
		cam = transform.parent.transform.GetComponentInChildren<Camera>();
		MyID = cam.gameObject.GetInstanceID();

		//cam.gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player"){

			_controller.SwitchBabyCam(MyID);
		}
	}
}
