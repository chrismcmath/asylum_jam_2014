using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
	
	private GameController GC;
	
	void Awake() {
		GC = GameObject.Find("Global").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Baby") {
			GC.GameOver();
		}
	}
}
