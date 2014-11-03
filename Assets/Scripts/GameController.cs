using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public enum GameStates {START, PLAYING, WIN, GAMEOVER};
	public GameStates GameState;
	public GameObject PlayerCam;
	public GameObject StartText;
	public GameObject TextPrefab;
	public Transform TextLocation;
	public GameObject Player;
	public BlackScreenUI BlackScreen;

    public bool _GameEnded = false;
    public bool _FinishedLoop = false;

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
                    if (BlackScreen != null) {
                        BlackScreen.FadeOut(2f);
                    }

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
        /*
		NextTextTime = Time.time + 2.0f;
		txt = "YOU SAVED DA BABBEYH! ";
		time = 10.0f;
		LoadTextStarted = true;
        */

        Debug.Log("Game ended, bool: " + _GameEnded);
        if (_GameEnded) {
            Debug.Log("fade in");
            if (!_FinishedLoop) {
                BlackScreen.FadeIn(10f);
                _FinishedLoop = true;
                GlobalConfig.Instance.CreditsUI.SetActive(true);
            }
            return;
        }

        _GameEnded = true;

        BlackScreen.FadeIn(4f);

        BabyModel.Instance.State = BabyModel.BabyState.OUT;
        GlobalConfig.Instance.Player.GetComponent<MovementActivator>().Deactivate();
        StartCoroutine(EndGameSequence());
	}

    private IEnumerator EndGameSequence() {
        yield return new WaitForSeconds(8.0f);

        Debug.Log("a");
		Player.BroadcastMessage("TurnOff");
		//PlayerCam.BroadcastMessage("ToggleFadeIn");
		//PlayerCam.BroadcastMessage("ToggleFadeOut");
        Debug.Log("b");
        GlobalConfig.Instance.PlayerDarkness.SetActive(true);
        Debug.Log("c");
        GlobalConfig.Instance.Player.GetComponent<MovementActivator>().Deactivate();
        Debug.Log("d");

        BlackScreen.FadeOut(0.1f);
        GlobalConfig.Instance.HorrorNoise.Play();
    }
	
	public void GameOver() {
		print ("GAME OVER");
        Debug.Log("1");
        BlackScreen.ToBlack();
        Debug.Log("2");
        BlackScreen.Text("Click to restart");
        Debug.Log("3");
        GlobalConfig.Instance.ScreamNoise.Play();
        Debug.Log("4");

        GameState = GameStates.GAMEOVER;
        /*j
		PlayerCam.BroadcastMessage("ToggleFadeIn");
		PlayerCam.BroadcastMessage("ToggleFadeOut");
		NextTextTime = Time.time + 2.0f;
		time = 99999.0f;
		LoadTextStarted = true;
        */
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
