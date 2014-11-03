using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
    public void Awake() {
        Debug.Log("launcher wakes");
        StartCoroutine(WaitThenLoad());
    }

    private IEnumerator WaitThenLoad() {
        Debug.Log("wait");
        yield return new WaitForSeconds(5f);
        Debug.Log("load level");
        Application.LoadLevel("lullaby");
    }
}
