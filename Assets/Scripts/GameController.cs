using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public enum GameStates {START, PLAYING, WIN, GAMEOVER};
	public GameStates GameState;
	public GameObject PlayerCam;
	public GameObject StartText;
	public GameObject TextPrefab;
	public Transform TextLocation;

	private bool LoadTextStarted;
	private float NextTextTime;
	private string txt;
	private float time;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//PlayerCam.BroadcastMessage("ChangeIntensity", 0.02f);

		switch (GameState) {
			case GameStates.START: 
				if (Input.GetMouseButtonDown(0)){
					StartText.SetActive(false);
					PlayerCam.BroadcastMessage("ToggleFadeIn");
					NextTextTime = Time.time + 2.0f;
					txt = "SAVE DA BABBEYH!";
					time = 5.0f;
					LoadTextStarted = true;
					GameState = GameStates.PLAYING;
				}
				break;

			case GameStates.PLAYING:
				
				break;

			case GameStates.GAMEOVER:
				if (Input.GetMouseButtonDown(0)){
				
					Application.LoadLevel(Application.loadedLevel);
				}
				break;


			case GameStates.WIN:

				break;

		}
	

		if (LoadTextStarted && Time.time > NextTextTime)
			LoadText();

	}
	
	public void GameWin() {
		print ("GAME WON!");
		//PlayerCam.BroadcastMessage("ToggleFadeIn");
		//PlayerCam.BroadcastMessage("ToggleFadeOut");
		NextTextTime = Time.time + 2.0f;
		txt = "YOU SAVED DA BABBEYH! ";
		time = 10.0f;
		LoadTextStarted = true;
	}
	
	
	public void GameOver() {
		print ("GAME OVER");
		PlayerCam.BroadcastMessage("ToggleFadeIn");
		PlayerCam.BroadcastMessage("ToggleFadeOut");
		NextTextTime = Time.time + 2.0f;
		txt = "YOU DIDNT SAVE DA BABBEYH! \n \n Click to try again... ";
		time = 99999.0f;
		LoadTextStarted = true;
	}
	

	void LoadText() {
		GameObject clone;
		clone = Instantiate(TextPrefab, TextLocation.position, TextLocation.rotation) as GameObject;
		clone.transform.parent = PlayerCam.transform;
		clone.GetComponent<TextMesh>().text = txt;
		Destroy(clone, time);
		txt = "";
		time = 0.0f;
		LoadTextStarted = false;
	}
}
