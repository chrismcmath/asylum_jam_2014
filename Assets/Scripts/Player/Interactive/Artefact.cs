using UnityEngine;
using System.Collections;

public class Artefact : HoldableObject {
    public string Key;

    public override void OnPickUp() {
        Debug.Log("OnPickUp " + Key);
        ArtefactCreator.Instance.Create(Key);
    }

    public override void OnPutDown() {
        ArtefactCreator.Instance.Destroy();
    }
}
