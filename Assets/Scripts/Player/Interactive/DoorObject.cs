using UnityEngine;
using System.Collections;

public class DoorObject : InteractiveObject {
	public bool TriggersDarkness;
	public DarknessController dRef;
	public bool OpenDoor;
	private float MaxRotation = 260.0f;
	public float RotationSpeed = 2.5f;

    public override bool OnAction() {
		OpenDoor = !OpenDoor;
        return false;
    }


	void FixedUpdate() {
		if (OpenDoor) {
			if (TriggersDarkness && dRef != null) {
				if (!dRef.Active) dRef.Active = true;
			}
			if (transform.eulerAngles.y > MaxRotation || transform.eulerAngles.y < 3 ){
				Vector3 newV = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y-RotationSpeed, transform.eulerAngles.z);
				transform.eulerAngles = newV;
			}
		} else {
			if (transform.eulerAngles.y > 0 && transform.eulerAngles.y < 357 ){
				Vector3 newV = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y+RotationSpeed, transform.eulerAngles.z);
				transform.eulerAngles = newV;
			}
		}
	}
}
