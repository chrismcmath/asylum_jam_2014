using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackScreenUI : MonoBehaviour {
    public Image BlackScreen;
    public Text Title;

    public void FadeIn() {
        BlackScreen.CrossFadeAlpha(255f, 2.0f, true);
    }

    public void FadeOut() {
        BlackScreen.CrossFadeAlpha(0f, 2.0f, true);
        Title.text = "";
    }
}
