using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float Speed;
    private float HorizontalMovement;
    private float VerticalMovement;

    // Start is called before the first frame update
    void Start() {
        Speed = 8f;
    }
    
    //mouse drag is when the user drags the spite using the mouse
    //this means on an andorid they drag the sprite with their finger
    private void OnMouseDrag() {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Speed);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }
}
