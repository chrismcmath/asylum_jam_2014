using UnityEngine;
using System.Collections;

public class SafePictureController : InteractiveObject {
    public override bool OnAction() {
        GetComponent<Rigidbody>().useGravity = true;
        return false;
    }
}
