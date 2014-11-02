using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SafeController : MonoBehaviour {
    public Text SafePasswordText; 
    private string _Password = "****";

    public AudioSource ErrorNoise;
    public AudioSource OpenNoise;

    public void OnInput(string input) {
        if (_Password.Length > 3) {
            _Password = "";
        }

        _Password += input;
        if (_Password.Length == 4) {
            Debug.Log("password " + _Password + " real: " + GlobalConfig.Instance.SafePassword);
            if (_Password == GlobalConfig.Instance.SafePassword) {
                OpenSafe();
            } else {
                ErrorNoise.Play();
            }
        }

        SafePasswordText.text = _Password;
    }

    private void OpenSafe() {
        Debug.Log("opensafe");
        OpenNoise.Play();
    }
}
