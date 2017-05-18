using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NAudio.Wave;

public class TargetGenerator : MonoBehaviour
{
    public GameObject target;
    public Transform player;
    public GameObject teleportBase;
    public GameObject teleportManager;
    public Text splashTime;
    public Text countTime;
    string splash;
    string count;

    public Quaternion shootDirection;
    public int stanceIndex;

    WaveFileReader wfr = new WaveFileReader(@"C:\Users\William\Desktop\BladeBeats\Assets\QHC.wav");
    BeatDetectorTest detector = new BeatDetectorTest();
    int length;
    public int timeDuration = 232;
    float timeDurationSeconds;
    public float delayTime = 1.7f;
    public int interval = 10;
    public int amplitude = 5000;
    bool Flag = false;
    public bool ableTeleport = false;
    public GameObject[] platform;
    public GameObject[] directionalTarget;
    //public Transform[] platform;
    public int platformIndex;
    public int playerPosIndex = 0;
    int index = 1;
    // Use this for initialization

    //This is the particlesystem
    public ParticleSystem[] flames;
    public bool status = false;
    // private int status = 1;

    void Start()
    {
        detector.WavReader(wfr);
        length = detector.length;
        detector.VarDefine();  //Define the variables
        detector.AudioProcess(); // Audio Process and Beats Detecting
        timeDurationSeconds = wfr.TotalTime.Seconds;

        StartCoroutine(TargetInitiate());

    }

    // Update is called once per frame
    void Update()
    {
        //timer.text = Time.time.ToString();
        //transform.LookAt(player);
        //shootDirection = transform.rotation;
        //shootDirection.eulerAngles = new Vector3(0, shootDirection.eulerAngles.y, 0);
    }
    private IEnumerator TargetInitiate()
    {
        //for (float i = 0; i < delayTime; i += Time.deltaTime)
        //{
        //    yield return 0;
        //}
        Debug.Log("Anything");

        Debug.Log("Drum timeduration: " + timeDurationSeconds);
        for (float i = 0; i < timeDuration; i += Time.deltaTime)
        {
            //print("For: " + i + " ,deltaTime: " + Time.deltaTime);
            var em0 = flames[0].GetComponent<ParticleSystem>().emission;
            var em1 = flames[1].GetComponent<ParticleSystem>().emission;
            var em2 = flames[2].GetComponent<ParticleSystem>().emission;
            var em3 = flames[3].GetComponent<ParticleSystem>().emission;
            var em4 = flames[4].GetComponent<ParticleSystem>().emission;
            var em5 = flames[5].GetComponent<ParticleSystem>().emission;
            var em6 = flames[6].GetComponent<ParticleSystem>().emission;
            var em7 = flames[7].GetComponent<ParticleSystem>().emission;
            em0.enabled = false;
            em1.enabled = false;
            em2.enabled = false;
            em3.enabled = false;
            em4.enabled = false;
            em5.enabled = false;
            em6.enabled = false;
            em7.enabled = false;

            if (status)
            {

                switch (playerPosIndex)
                {
                    case 0:
                        em0.enabled = false;
                        em1.enabled = false;
                        break;
                    case 1:
                        em2.enabled = false;
                        em3.enabled = false;
                        break;
                    case 2:
                        em4.enabled = false;
                        em5.enabled = false;
                        break;
                    case 3:
                        em6.enabled = false;
                        em7.enabled = false;
                        break;
                }

            }
            else
            {
                switch (playerPosIndex)
                {
                    case 0:
                        em0.enabled = true;
                        em1.enabled = true;
                        break;
                    case 1:
                        em2.enabled = true;
                        em3.enabled = true;
                        break;
                    case 2:
                        em4.enabled = true;
                        em5.enabled = true;
                        break;
                    case 3:
                        em6.enabled = true;
                        em7.enabled = true;
                        break;
                }


            }
          //  splashTime.text = splash;
            //countTime.text = count;

            //float seconds = instantiateTime - flameTime;
            //timer.text = seconds.ToString();
           // timer.text = instantiateTime;

            while (platformIndex == playerPosIndex || platformIndex >= platform.Length)
            {
                platformIndex = Random.Range(0, 4);
            }
            if (detector._beat[(int)((i / (timeDuration + 0.23f)) * (length / 1024))] == 0 && detector._beat[(int)((i / (timeDuration + 0.23)) * (length / 1024)) + 1] == 1)
            {


                switch (index)
                {
                    case 1:
                        GetComponent<Renderer>().material.color = Color.red;
                        GameObject newTarget = Instantiate(target, transform.position, shootDirection); // Insatantiate a enemy
                        Debug.Log("Initiate");
                        Destroy(newTarget, 30f);
                        //print("flag1: " + Flag + ", time: " + Time.time);
                        // Debug.Log("num = " + (int)((i / timeDuration) * (length / 1024)) + "Time = " + Time.time);
                        index = 2;
                        status = !status;
           //             splash = Time.time.ToString(); ;
                        break;

                    case 2:
                        index = 3;
                        // status = 3;
                        break;
                    case 3:
                        index = 4;
                        break;
                    case 4:
                        index = 5;
                        //status = 0;
                        break;
                    case 5:


                        // platformIndex = Random.Range(0, 4);
                        playerPosIndex = platformIndex;
                        transform.LookAt(directionalTarget[platformIndex].transform);
                        shootDirection = transform.rotation;
                        shootDirection.eulerAngles = new Vector3(0, shootDirection.eulerAngles.y, 0);
                        platform[platformIndex].GetComponent<Renderer>().material.color = Color.red;  // Color change to teleport           
                        index = 6;
                        status = !status;
         //               count = Time.time.ToString();
                        //  Debug.Log("num = " + (int)((i / timeDuration) * (length / 1024)) + "Time = " + Time.time);
                        break;
                    case 6:
                        index = 7;
                        break;
                    case 7:
                        index = 8;
                        break;
                    case 8:
                        index = 1;
                        break;

                }
                // Debug.Log("Switch  Off "+ Time.time);
            }

            else
            {
                GetComponent<Renderer>().material.color = Color.red;
                //ableTeleport = true;
                if (platformIndex < platform.Length)
                {
                    platform[platformIndex].GetComponent<Renderer>().material.color = Color.white;
                }
                // Debug.Log("Else  Off " + Time.time);
            }
            //Debug.Log("Else  Off");
            yield return 0;
        }
    }
}
