using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausecanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }
    private void pause()//only pause player movment, need update
    {
        this.GetComponent<playerMovment>().enabled = !this.GetComponent<playerMovment>().enabled;
        pausecanvas.active = !pausecanvas.active;
    }
}
