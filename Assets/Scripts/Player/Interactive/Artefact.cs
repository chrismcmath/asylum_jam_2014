using UnityEngine;
using System.Collections;

public class Artefact : HoldableObject {
    public string Key;

    public override bool OnPickUp() {
        ArtefactCreator.Instance.Create(Key);
        return true;
    }

    public override bool OnPutDown() {
        ArtefactCreator.Instance.Destroy();
        return true;
    }
}
