using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio.Wave;

public class TargetGenerator : MonoBehaviour
{
    public GameObject target;
    public Transform player;
    public GameObject teleportBase;
    public GameObject teleportManager;

    public Quaternion shootDirection;
    public int stanceIndex;

    WaveFileReader wfr = new WaveFileReader(@"D:\BeatDetectionProgram\Assets\QHC.wav");
    BeatDetectorTest detector = new BeatDetectorTest();
    int length;
    public int timeDuration = 232;
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
    void Start()
    {
        detector.WavReader(wfr);
        length = detector.length;
        detector.VarDefine();  //Define the variables
        detector.AudioProcess(); // Audio Process and Beats Detecting
        StartCoroutine(TargetInitiate());

    }

    // Update is called once per frame
    void Update()
    {
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
        for (float i = 0; i < timeDuration; i += Time.deltaTime)
        {
            //print("For: " + i + " ,deltaTime: " + Time.deltaTime);


            if (detector._beat[(int)((i / timeDuration) * (length / 1024))] == 0 && detector._beat[(int)((i / timeDuration) * (length / 1024)) + 1] == 1)
            {

                switch (index)
                {
                    case 1:
                        GetComponent<Renderer>().material.color = Color.red;
                        GameObject newTarget = Instantiate(target, transform.position, shootDirection); // Insatantiate a enemy
                        Destroy(newTarget, 30f);
                        //print("flag1: " + Flag + ", time: " + Time.time);
                        Debug.Log("num = " + (int)((i / timeDuration) * (length / 1024)) + "Time = " + Time.time);
                        index = 2;
                        break;

                    case 2:
                        index = 3;
                        break;
                    case 3:
                        while (platformIndex == playerPosIndex || platformIndex >= platform.Length)
                        {
                            platformIndex = Random.Range(0, 4);
                        }
                        // platformIndex = Random.Range(0, 4);
                        playerPosIndex = platformIndex;
                        transform.LookAt(directionalTarget[platformIndex].transform);
                        shootDirection = transform.rotation;
                        shootDirection.eulerAngles = new Vector3(0, shootDirection.eulerAngles.y, 0);
                        platform[platformIndex].GetComponent<Renderer>().material.color = Color.red;  // Color change to teleport           
                        index = 4;
                        Debug.Log("num = " + (int)((i / timeDuration) * (length / 1024)) + "Time = " + Time.time);
                        break;                    
                    case 4:
                        index = 1;
                        break;
                }
                Debug.Log("Switch  Off "+ Time.time);
            }

            //    if (!Flag)
            //    {
            //        //ableTeleport = true;
            //        //platform[platformIndex].GetComponent<Renderer>().material.color = Color.red;
            //        while (platformIndex == playerPosIndex || platformIndex >= platform.Length)
            //        {
            //            platformIndex = Random.Range(0, 4);
            //        }
            //        // platformIndex = Random.Range(0, 4);
            //        playerPosIndex = platformIndex;
            //        transform.LookAt(platform[platformIndex].transform);
            //        shootDirection = transform.rotation;
            //        shootDirection.eulerAngles = new Vector3(0, shootDirection.eulerAngles.y, 0);


            //        GetComponent<Renderer>().material.color = Color.red;
            //        GameObject newTarget = Instantiate(target, transform.position, shootDirection); // Insatantiate a enemy
            //        Destroy(newTarget, 30f);
            //        print("flag1: " + Flag + ", time: " + Time.time);
            //        Flag = true;
            //        // yield return 0;
            //    }
            //    else
            //    {


            //        platform[platformIndex].GetComponent<Renderer>().material.color = Color.red;  // Color change to teleport                
            //        Flag = false;
            //        // yield return 0;

            //    }

            //}

            else
            {
                GetComponent<Renderer>().material.color = Color.red;
                //ableTeleport = true;
                if (platformIndex < platform.Length)
                {
                    platform[platformIndex].GetComponent<Renderer>().material.color = Color.white;
                }
                Debug.Log("Else  Off " + Time.time);
            }
            //Debug.Log("Else  Off");
            yield return 0;
        }
    }
}
