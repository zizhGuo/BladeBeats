using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio.Wave;

public class TargetGenerator : MonoBehaviour
{
    public GameObject target;
    public Transform player;

    public Quaternion shootDirection;
    public int stanceIndex;

    WaveFileReader wfr = new WaveFileReader(@"D:\BeatDetectionProgram\Assets\QHC.wav");
    BeatDetectorTest detector = new BeatDetectorTest();
    int length;
    public int timeDuration = 232;
    public float delayTime = 1.7f;
    public int interval = 10;
    public int amplitude = 5000;

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
        transform.LookAt(player);
        shootDirection = transform.rotation;
        shootDirection.eulerAngles = new Vector3(0, shootDirection.eulerAngles.y, 0);
    }
    private IEnumerator TargetInitiate()
    {
        //for (float i = 0; i < delayTime; i += Time.deltaTime)
        //{
        //    yield return 0;
        //}

        bool Flag = true;

        for (float i = 0; i < timeDuration; i += Time.deltaTime)
        {
            
            if (detector._beat[(int)((i / timeDuration) * (length / 1024))] == 0 && detector._beat[(int)((i / timeDuration) * (length / 1024))+1] == 1 && Flag == true)
            {
                GetComponent<Renderer>().material.color = Color.black;
                GameObject newTarget = Instantiate(target, transform.position, shootDirection);
                Destroy(newTarget, 30f);
                Flag = false;
            }
            if (detector._beat[(int)((i / timeDuration) * (length / 1024))] != 1)
            {
                GetComponent<Renderer>().material.color = Color.red;
                //color = Color.red;
            }
            //if (detector._beat[(int)((i / timeDuration) * (length / 1024))] == 1 && Flag == false)
            //{
            //    Flag = true;
            //}
            yield return 0;
        }
        // yield return 0;
    }
}
