using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TargetGenerator generator;
    public InkSpill collisionTime;
    public Text timer;
    public Text timer2;
    float time;
    float time2;
    float interval;
    bool flag;
    float currentTime;
    float previousTime;
    // Use this for initialization
    void Start()
    {
        flag = true;
        previousTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (generator.status)
        {
            interval = currentTime + interval;
            currentTime = 0;
            previousTime = 0;
            time = Time.time;

        }
        else
        {
            currentTime = previousTime + Time.deltaTime;
            previousTime = currentTime;           
            timer.text = currentTime.ToString();
        }
        if (collisionTime.collisionTime - time > 1.1f)
        {
            timer2.text = "Gotya";
        }
    }
}
