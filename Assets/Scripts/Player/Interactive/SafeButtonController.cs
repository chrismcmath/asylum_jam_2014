using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TinyTween;

public class SafeButtonController : InteractiveObject {
    public Text Label;

    public void Awake() {
        Label.text = gameObject.name;
    }

    public override bool OnAction() {
        gameObject.GetComponent<AudioSource>().Play();
        GlobalConfig.Instance.SafeController.OnInput(gameObject.name);
        return false;
    }
}
