using UnityEngine;
using System.Collections;

public class BabyController : HoldableObject {
    public AudioSource SleepNoise;
    public AudioSource CryNoise;

    private Transform _BabyDockAnchor;
	private GameController GC;
	
	void Awake() {
		GC = GameObject.Find("Global").GetComponent<GameController>();

        BabyModel.Instance.AddStateChangeListener(OnStateChange);
        CryNoise.Play();
    }

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Baby") {
			GC.GameWin();
		}
	}

    public override bool OnPickUp() {
        GetComponent<Collider>().enabled = false;
        transform.parent = GlobalConfig.Instance.PlayerBabyRoot;
        TweenToZero(GlobalConfig.Instance.FocusObjectTweenTime);

        BabyModel.Instance.State = BabyModel.BabyState.HELD;
        return true;
    }

    public override bool OnPutDown() {
        BabyDockController babyDock = GetBabyDock();
        if (babyDock == null) {
            Debug.Log("No babyDock found");
            return false;
        }

        _BabyDockAnchor = babyDock.Anchor;
        BabyModel.Instance.State = BabyModel.BabyState.DOWN;

        return true;
    }

    public void OnStateChange(BabyModel.BabyState state) {
        switch (state) {
            case BabyModel.BabyState.HELD:
                OnBabyHeld();
                break;
            case BabyModel.BabyState.DOWN:
                OnBabyDown();
                break;
            case BabyModel.BabyState.CRY:
                OnBabyCry();
                break;
            case BabyModel.BabyState.OUT:
                transform.parent = GlobalConfig.Instance.SceneRoot;
                CryNoise.Stop();
                SleepNoise.Stop();
                break;
        }
    }

    private void OnBabyHeld() {
        CryNoise.Stop();
        SleepNoise.Play();
    }
    private void OnBabyDown() {
        GetComponent<Collider>().enabled = true;
        SleepNoise.Stop();
        CryNoise.Play();

        if (_BabyDockAnchor == null) {
            Debug.Log("ERROR No _BabyDockAnchor set");
        }
        transform.parent = _BabyDockAnchor;
        TweenToZero(GlobalConfig.Instance.FocusObjectTweenTime);
    }
    private void OnBabyCry() {
    }

    private BabyDockController GetBabyDock() {
        Transform sourceTransform = GlobalConfig.Instance.PlayerCamera.transform;
        Vector3 forward = sourceTransform.TransformDirection(Vector3.forward) * 100f;

        RaycastHit[] hits;
        hits = Physics.RaycastAll(sourceTransform.position, forward, 2f);
        Debug.DrawRay(GlobalConfig.Instance.Player.transform.position, forward, Color.green);
        int i = 0;
        while (i < hits.Length) {
            RaycastHit hit = hits[i];

            BabyDockController babyDock = hit.collider.gameObject.GetComponent<BabyDockController>();
            if (babyDock != null) {
                return babyDock;
            }
            i++;
        }
        return null;
    }
}
