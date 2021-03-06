using UnityEngine;
using System.Collections;

public class Artefact : HoldableObject {
    public string Key;

    public AudioSource PaperNoise;

    public override bool OnPickUp() {
        ArtefactCreator.Instance.Create(Key);
        PaperNoise.Play();
        return true;
    }

    public override bool OnPutDown() {
        Debug.Log("on put down Artefact");
        ArtefactCreator.Instance.Destroy();
        return true;
    }
}
