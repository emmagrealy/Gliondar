using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {
    private float RotationSpeed;
    // Start is called before the first frame update
    void Start() {
        RotationSpeed = 50f;
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
    }
}
