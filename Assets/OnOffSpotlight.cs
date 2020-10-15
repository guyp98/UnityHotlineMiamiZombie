using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    private void activateDis()
    {
        light.active = !light.active;
    }
}
