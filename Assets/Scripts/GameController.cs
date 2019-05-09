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
    public GameObject[] balls;
    public Text timetext;


    public GameObject restartbtn;
    public GameObject gameovertxt;


    public GameObject startbtn;


    private bool playing;



    public Bubblemove Bubblemove;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;

        }
        playing = false;

        //regid body components
        rb = GetComponent<Rigidbody2D>();
        ballrenderer = balls[0].GetComponent<Renderer>();

     
        Vector3 uppercorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(uppercorner);
        float ballWidth = ballrenderer.bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;


    }

    public void StartGame() {
        //splash goes here too
        startbtn.SetActive(false);

        Bubblemove.ToggleControl(true);
        StartCoroutine(Spawn());


    }

    private void FixedUpdate()
    {
        if (playing)
        {
            timeleft -= Time.deltaTime;
            if (timeleft < 0)
            {
                timeleft = 0;
            }
            timetext.text = "Time: " + Mathf.RoundToInt(timeleft).ToString();
        }
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(0.0f);
        playing = true;


        while (timeleft > 0)
        {
            GameObject ball = balls[Random.Range(0, balls.Length)];

            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth+0.5f, maxWidth-0.5f), 13, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
        }


        yield return new WaitForSeconds(1.0f);
        gameovertxt.SetActive(true);
        yield return new WaitForSeconds(1.02f);
        restartbtn.SetActive(true);

    }
}
