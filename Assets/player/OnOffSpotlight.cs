using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class OnOffSpotlight : MonoBehaviour
{
    public GameObject light;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            activateDis();
        }
        blinkeringEffect(0.03f);
    }
    private void activateDis()
    {
        light.active = !light.active;
    }
    private void blinkeringEffect(float delay)
    {
        float x = Random.Range(0f, 1200f);
        if (light.active==true&&x<2f) {
            StartCoroutine(Blink(delay));
        }
    }
    IEnumerator Blink(float delay)  
    {
        activateDis();
        yield return new WaitForSeconds(delay);
        activateDis();
        yield return new WaitForSeconds(delay);
        activateDis();
        yield return new WaitForSeconds(delay);
        activateDis();
    }
}
