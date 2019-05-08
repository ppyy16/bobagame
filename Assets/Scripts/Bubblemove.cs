using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubblemove : MonoBehaviour
{

    public Camera cam;
    private Rigidbody2D rb;
    private Renderer tearenderer;
    private float maxWidth;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null) {
            cam = Camera.main;

        }

        //regid body components
        rb = GetComponent<Rigidbody2D>();
        tearenderer = GetComponent<Renderer>();

        Vector3 uppercorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(uppercorner);
        float cupWidth = tearenderer.bounds.extents.x;
        maxWidth = targetWidth.x - cupWidth;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //inital position hold down control
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        rb.MovePosition(targetPosition);



    }
}
