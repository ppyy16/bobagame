using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera cam;
    private Rigidbody2D rb;
    private Renderer ballrenderer;
    private float maxWidth;
    public float timeleft;
    public GameObject ball;
    public Text timetext;


    public GameObject restartbtn;
    public GameObject gameovertxt;


    public GameObject startbtn;

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


    }

    public void StartGame() {
        //splash goes here too
        startbtn.SetActive(false);
        StartCoroutine(Spawn());


    }

    private void FixedUpdate()
    {
        timeleft -= Time.deltaTime;
        if (timeleft < 0) {
            timeleft = 0;
        }
        timetext.text = "Time: " + Mathf.RoundToInt(timeleft).ToString();

    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(0.0f);
        while (timeleft > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth+0.5f, maxWidth-0.5f), 13, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(Random.Range(0.3f, 1.0f));
        }

        yield return new WaitForSeconds(1.0f);
        gameovertxt.SetActive(true);
        yield return new WaitForSeconds(1.02f);
        restartbtn.SetActive(true);

    }
}
