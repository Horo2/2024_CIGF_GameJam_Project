using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCatch : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        // Set the Render Mode to Screen Space - Camera
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        // Assign the Camera to the Canvas
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
