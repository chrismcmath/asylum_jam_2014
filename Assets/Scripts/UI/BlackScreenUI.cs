using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackScreenUI : MonoBehaviour {
    public Image BlackScreen;
    public Text Title;

    public void FadeIn(float speed) {
        BlackScreen.CrossFadeAlpha(1f, speed, true);
    }

    public void FadeOut(float speed) {
        BlackScreen.CrossFadeAlpha(0f, speed, true);
        Title.text = "";
    }

    public void ToBlack() {
        BlackScreen.CrossFadeAlpha(1f, 0.1f, true);
    }

    public void Text(string text) {
        Title.text = text;
    }
}
