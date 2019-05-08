using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera cam;
    private Rigidbody2D rb;
    private Renderer ballrenderer;
    private float maxWidth;

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;

        }

        //regid body components
        rb = GetComponent<Rigidbody2D>();
        ballrenderer = GetComponent<Renderer>();

        Vector3 uppercorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(uppercorner);
        float ballWidth = ballrenderer.bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        StartCoroutine(Spawn());


    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), 13, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(Random.Range(0.3f, 1.0f));
        }

    }
}
