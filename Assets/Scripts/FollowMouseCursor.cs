using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    private float screenWidth;
    private float screenHeight;

    private void Start() {
        cam = Camera.main;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }
    private void Update() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0f; 
  
        // transform.position =mousePos;
        transform.position = mousePos;
    }

}
