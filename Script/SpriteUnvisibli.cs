using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteUnvisibli : MonoBehaviour
{
    SpriteRenderer spf;

    void Start()
    {
        spf = GetComponent<SpriteRenderer>();
        Color color = spf.material.color;
        color.a = 0f;
        spf.material.color = color;
    }

    IEnumerator Invisible()
    {
        for(float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color color = spf.material.color;
            color.a = f;
            spf.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.0f);

        for(float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color color = spf.material.color;
            color.a = f;
            spf.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    //IEnumerator Uninvisible()
    //{
    //    for(float f = 1f; f >= 1f; f -= 0.05f)
    //    {
    //        Color color = spf.material.color;
    //        color.a = f;
    //        spf.material.color = color;
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //}

    public void StartInvisible()
    {
        StartCoroutine("Invisible");
        //InvokeRepeating("Uninvisible", 0.5f,1);
        //StartCoroutine("Uninvisible");
    }
}