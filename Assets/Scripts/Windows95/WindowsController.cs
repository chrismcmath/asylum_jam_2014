using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindowsController : MonoBehaviour {
    public readonly static string PATH_WINDOWS = "Windows95/{0}";

    public Image Background;
    public GameObject PasswordFile;
    public GameObject NoBattery;
    public GameObject Desktop;
    public GameObject Login;
    public AudioSource ComputerStartup;
    public AudioSource WindowsStartup;

    public GameObject Cursor;

    private int _BackgroundKey = 0; 
    private bool _IsOn = false;
    private bool _CursorAvailable = true;

    private void SetBackground(string key) {
        SetSprite(key, Background);
    }

    private void SetSprite(string key, Image img) {
        img.color = Color.white;
        Sprite s = Resources.Load(string.Format(PATH_WINDOWS, key), typeof(Sprite)) as Sprite;
        if (s != null) {
            img.sprite = s;
        } else {
            Debug.Log("Could not find windows sprite with key " + key);
        }
    }

    private void ProgressBackground() {
        _BackgroundKey++;
        SetBackground(_BackgroundKey.ToString());
    }

    public void OnFileClicked() {
        PasswordFile.SetActive(true);
    }

    public bool OnCheckPassword(string password) {
        if (password.ToLower() == GlobalConfig.Instance.ComputerPassword) {
            Login.SetActive(false);
            WindowsStartup.Play();
            SetBackground("4");
            Desktop.SetActive(true);
            return true;
        }

        return false;
    }

    public void OnFocus() {
        if (!_IsOn) {
            TryTurnOn();
        }

        if (_CursorAvailable) {
            Cursor.SetActive(true);
        }
    }

    public void OnDefocus() {
        Cursor.SetActive(false);
    }

    private void TryTurnOn() {
        if (PlayerModel.Instance.HasPowerAdaptor) {
            BootComputer();
        } else {
            NoBattery.SetActive(true);
            StartCoroutine(DeactivateAfterDelay(NoBattery, GlobalConfig.Instance.BatteryDisappearDelay));
        }
    }

    private IEnumerator DeactivateAfterDelay(GameObject go, float delay) {
        yield return new WaitForSeconds(delay);

        go.SetActive(false);
    }

    private void BootComputer() {
        StartCoroutine(ProgressBackgroundAfterWait(0.0f));
    }

    private IEnumerator ProgressBackgroundAfterWait(float delay) {
        yield return new WaitForSeconds(delay);

        ProgressBackground();

        switch (_BackgroundKey) {
            case 1:
                ComputerStartup.Play();
                break;
            case 2:
                break;
        }

        if (_BackgroundKey < 3) {
            StartCoroutine(ProgressBackgroundAfterWait(20.0f));
        } else {
            Login.SetActive(true);
            _CursorAvailable = true;
            Cursor.SetActive(true);
        }
    }
}
