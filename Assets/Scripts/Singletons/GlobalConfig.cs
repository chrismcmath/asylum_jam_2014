using UnityEngine;
using System.Collections;

public class GlobalConfig : Singleton<GlobalConfig> {
	public GameObject Player;
	public Transform PlayerObjectRoot;
	public Transform SceneRoot;
    public LayerMask InteractionLayerMask;
}
