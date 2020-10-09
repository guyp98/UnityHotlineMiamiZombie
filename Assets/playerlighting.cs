using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlighting : MonoBehaviour
{

    public GameObject Spotlight;
    public GameObject GeneralLight;


    
    void Update()
    {
        numbersKeysToSelect();
    }

    private void numbersKeysToSelect()
    {
        if (Input.GetKeyDown(KeyCode.E)) { Spotlight.SetActive(!Spotlight.activeSelf); }
      /*  if (Input.GetKeyDown(KeyCode.Alpha2)) { SubHealth(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { NewMaxLimit(1); }

        if (Input.GetKeyDown(KeyCode.Alpha4)) { NewMaxLimit(-1); }
    */
    }
}

