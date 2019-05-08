using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubblemove : MonoBehaviour
{

    public Camera cam;
    private Rigidbody2D rb;
    private Renderer tearenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null) {
            cam = Camera.main;

        }

        //regid body components
        rb = GetComponent<Rigidbody2D>();
        tearenderer = GetComponent<Renderer>();



    }

    // Update is called once per frame
    void Update()
    {
        //inital position hold down control
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
        rb.MovePosition(targetPosition);

    }
}
