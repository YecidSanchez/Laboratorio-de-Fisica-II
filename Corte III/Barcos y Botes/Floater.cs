using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour {

public Rigidbody rigidBody;
public float depthBeforeSubmerged = 0.5f;
public float displacementAmount = 3.0f;

    private void FixedUpdate() {
        if (transform.position.y < 0.0f) {
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rigidBody.AddForce(new Vector3(0.0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0.0f), ForceMode.Acceleration);
        }
    }
}