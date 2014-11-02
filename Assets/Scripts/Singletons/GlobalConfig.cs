using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalConfig : Singleton<GlobalConfig> {
    public void Awake() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

	public GameObject Player;
	public GameObject PlayerCamera;
	public Transform PlayerObjectRoot;
	public Transform SceneRoot;
    public LayerMask InteractionLayerMask;
    public WindowsController WindowsController;

    public GameObject ArtefactRoot;
    public Image ArtefactImage;

    public float FocusObjectTweenTime = 2f;
    public float BatteryDisappearDelay = 2f;
    public string ComputerPassword = "sarah";
}
