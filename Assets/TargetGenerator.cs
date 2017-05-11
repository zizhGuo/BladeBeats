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


        print("song length: " + timeDuration);

        for (float i = 0; i < timeDuration; i += Time.deltaTime)
        {
            //print("For: " + i + " ,deltaTime: " + Time.deltaTime);


            if (detector._beat[(int)((i / timeDuration) * (length / 1024))] == 1)
            {
                print("outer if");

                if (!Flag)
                {
                    //ableTeleport = true;
                    //platform[platformIndex].GetComponent<Renderer>().material.color = Color.red;



                    GetComponent<Renderer>().material.color = Color.red;
                    GameObject newTarget = Instantiate(target, transform.position, shootDirection);
                    Destroy(newTarget, 30f);
                    print("flag1: " + Flag + ", time: " + Time.time);
                    Flag = true;
                }
                else
                {
                    while (platformIndex == playerPosIndex || platformIndex >= platform.Length)
                    {
                        platformIndex = Random.Range(0, 4);
                    }

                    playerPosIndex = platformIndex;

                    //print("platformIndex: " + platformIndex + ", " + platform.Length);
                    transform.LookAt(platform[platformIndex].transform);
                    shootDirection = transform.rotation;
                    shootDirection.eulerAngles = new Vector3(0, shootDirection.eulerAngles.y, 0);

                    platform[platformIndex].GetComponent<Renderer>().material.color = Color.black;
                    Flag = false;
                    print("flag2: " + Flag + ", time: " + Time.time);
                }
            }

            else
            {
                print("outer else");
                GetComponent<Renderer>().material.color = Color.red;
                //if (teleportManager.playerPos)
                //{

                //} 
                ableTeleport = true;

                if (platformIndex < platform.Length)
                {
                    platform[platformIndex].GetComponent<Renderer>().material.color = Color.white;
                }

                //color = Color.red;
            }
            yield return null;
        }
        // yield return 0;
    }
}
