using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalConfig : Singleton<GlobalConfig> {
	public GameObject Player;
	public GameObject PlayerCamera;
	public Transform PlayerObjectRoot;
	public Transform SceneRoot;
    public LayerMask InteractionLayerMask;

    public GameObject ArtefactRoot;
    public Image ArtefactImage;

    public float FocusObjectTweenTime = 2f;
}
