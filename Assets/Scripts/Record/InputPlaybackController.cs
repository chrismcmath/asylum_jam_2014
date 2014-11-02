using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* 
 * Record player input and play it back
 * 
 * 
 */

public class InputPlaybackController : MonoBehaviour {
	public bool PlaybackEnabled = true;
	public bool isPlayer;
	public bool isBaby;
	public GameObject DarknessEffect;

	List<Vector3> RecordedPositions = new List<Vector3>();
	List<Vector3> RecordedRotations = new List<Vector3>();

	public int PlaybackIndex = 0;

	public Component[] DisableList;

	private RecordConfigSimple _config;
	private GameController GC;
	private bool turnedOff;
	
	void Awake() {
		GC = GameObject.Find("Global").GetComponent<GameController>();

		_config = GameObject.Find("Global").GetComponent<RecordConfigSimple>();
	}

	// Use this for initialization
	void Start () {
		//RecordedPositions = new ArrayList();
		InvokeRepeating("Record",0, 1.0f/_config.RecordRate);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			TurnOff();
		}

		if (!turnedOff && GC.GameState == GameController.GameStates.WIN ) {
			TurnOff();
		}

	}

	void FixedUpdate() {
		if (!_config.isRecording) Playback();
	}

	public void TurnOff(){

		if (isPlayer) {
			DarknessEffect.SetActive(true);
		}
		if (isBaby) {
			transform.parent = null;
		}

		DisableComponents();
		turnedOff = true;
		
		_config.isRecording = false;
	}
	
	public void Playback() {
		// dont playback but reset if we're not enabling playback
		if (!PlaybackEnabled) {			
			transform.position = RecordedPositions[PlaybackIndex];
			transform.eulerAngles = RecordedRotations[PlaybackIndex];

			gameObject.SetActive(false);
			return;
		}

		transform.position = RecordedPositions[PlaybackIndex];
		transform.eulerAngles = RecordedRotations[PlaybackIndex];
		PlaybackIndex++;

		// temporarly restart
		if (PlaybackIndex == RecordedPositions.Count) PlaybackIndex = 0;
	}

	public void Record() {
		// save our current position and rotation

		if (!_config.isRecording)
			return;

		RecordedPositions.Add(transform.position);
		RecordedRotations.Add(transform.eulerAngles);
	}

	public void DisableComponents(){
		//disable player cam
		Camera cam = GetComponentInChildren<Camera>();
		if (cam != null) cam.gameObject.SetActive(false);

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
