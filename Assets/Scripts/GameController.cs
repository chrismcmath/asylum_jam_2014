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
        if (_GameEnded) {
            if (!_FinishedLoop) {
                BlackScreen.FadeIn(10f);
                _FinishedLoop = true;
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

		Player.BroadcastMessage("TurnOff");
        GlobalConfig.Instance.PlayerDarkness.SetActive(true);

        StartCoroutine(ShowCreditsAfterWait());
        BlackScreen.FadeOut(0.1f);
        GlobalConfig.Instance.HorrorNoise.Play();
    }

    private IEnumerator ShowCreditsAfterWait() {
        yield return new WaitForSeconds(5.0f);
        GlobalConfig.Instance.CreditsUI.SetActive(true);
    }
	
	public void GameOver() {
        BlackScreen.ToBlack();
        BlackScreen.Text("Click to restart");
        GlobalConfig.Instance.ScreamNoise.Play();

        GameState = GameStates.GAMEOVER;
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
