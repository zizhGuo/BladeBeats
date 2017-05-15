using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFlame : MonoBehaviour
{
    public GameObject[] flames;
    int platformIndex = 0;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(FlamesOn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator FlamesOn()
    {
        //for (float i = 0; i < 100f; i += Time.deltaTime)
        //{
        //    platformIndex = Random.Range(0, 4);
        //    if (i % 2 == 1)
        //    {
        //        var 
        //        flames[platformIndex].GetComponent<ParticleSystem>().emission.enabled;
        //    }
        //      flames[platformIndex].GetComponent<ParticleSystem>().enableEmission = false;
       // }
        yield return 0;
    }
}
