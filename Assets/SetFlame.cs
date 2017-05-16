using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFlame : MonoBehaviour
{
    public ParticleSystem[] flames;
    int platformIndex = 0;
    bool status = false;
    int flag = 0;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(FlamesOn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator FlamesOn()
    {

      
        for (float i = 0; i < 100f; i += Time.deltaTime)
        {
            var em0 = flames[0].GetComponent<ParticleSystem>().emission;
            var em1 = flames[1].GetComponent<ParticleSystem>().emission;
            //em0.enableEmission = true;
            //em1.enabled = false;
            Debug.Log("Out " + Time.time);
            platformIndex = Random.Range(0, 4);
            if (flag > 10)
            {
                Debug.Log("Enter the IF " + Time.time);
                if (!status)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }

            if (!status)
            {

                em0.enabled = false;
                em1.enabled = false;
            }
            else
            {
                em0.enabled = true;
                em1.enabled = true;

            }
            flag++;
            //flames[platformIndex].GetComponent<ParticleSystem>().enableEmission = false;
        }

        yield return 0;
    }
}
