using UnityEngine;
using System.Collections;

public class BabyCamController : MonoBehaviour {
	public int ActiveID = 0;
	public Camera[] BabyCams;
	public int[] BabyCamIDlist;
	
	private RecordConfigSimple _config;
	
	void Awake() {
		_config = GetComponent<RecordConfigSimple>();

		// also turn off all cams on start
		TurnOffAllCams();
	}

	public void SwitchBabyCam( int refID ) {
		// dont change if we're still recording
		if (_config.isRecording)
			return;

		// get id
		int id = GetCamID(refID);
		ActiveID = id;

		if ( id == -1 ) {
			print("Baby cam id not found in list of available cams! id: " + id );
			return;
		}

		print ("Trigger baby cam id: " + id);

		//turn off all cams except our switch id
		for (int i=0; i<BabyCams.Length; i++) {
			if (i==id) {
				BabyCams[i].enabled = true;
				BabyCams[i].GetComponent<AudioListener>().enabled = true;
			} else {
				BabyCams[i].enabled = false;
				BabyCams[i].GetComponent<AudioListener>().enabled = false;
			}
		}
	}

	private int GetCamID( int refID) {
		int id = -1;

		// find ID of gameobject that called this function
		for (int i=0; i<BabyCams.Length; i++) {
			print (refID + " vs: " + BabyCams[i].gameObject.GetInstanceID() );

			if (BabyCams[i].gameObject.GetInstanceID() == refID)
				id = i;
		}

		return id;
	}

	public void TurnOffAllCams() {
		foreach (Camera c in BabyCams){
			c.enabled = false;
			c.GetComponent<AudioListener>().enabled = false;
		}

	}

}
