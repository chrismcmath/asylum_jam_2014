using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* 
 * Record player input and play it back
 * 
 * 
 */

public class InputPlaybackController : MonoBehaviour {
	List<Vector3> RecordedPositions = new List<Vector3>();
	List<Vector3> RecordedRotations = new List<Vector3>();

	public bool isRecording = true;
	public int PlaybackIndex = 0;

	public Component[] DisableList;

	// Use this for initialization
	void Start () {
		//RecordedPositions = new ArrayList();
		InvokeRepeating("Record",0, 1.0f/RecordConfig.Instance.RecordRate);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Backspace)) {

			/*
			string debugInfo = "";
			foreach (Vector3 v in RecordedPositions) {
				debugInfo += v + " : ";
			}
			print (debugInfo);
			*/
			DisableComponents();
			isRecording = false;
		}
	}

	void FixedUpdate() {
		if (!isRecording) Playback();
	}

	public void Playback() {
		transform.position = RecordedPositions[PlaybackIndex];
		transform.eulerAngles = RecordedRotations[PlaybackIndex];
		PlaybackIndex++;

		// temporarly restart
		if (PlaybackIndex == RecordedPositions.Count) PlaybackIndex = 0;
	}

	public void Record() {
		// save our current position and rotation

		if (!isRecording)
			return;

		RecordedPositions.Add(transform.position);
		RecordedRotations.Add(transform.eulerAngles);
	}

	public void DisableComponents(){
		//disable components
		MouseLook[] m = GetComponentsInChildren<MouseLook>();
		foreach (MouseLook s in m) {
			s.enabled = false;
		}

		//disable physic stuff
		Rigidbody[] r = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rr in r) {
			rr.isKinematic = true;
		}
	}
}
