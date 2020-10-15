using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class CheckBoss : MonoBehaviour
{
    public float speed = 10;
    public bool burst = false;
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<enemyGFX>().isBoss && burst)
        {
            GetComponent<enemyGFX>().speed = speed;
        }
        else
        {
            GetComponent<enemyGFX>().speed = 2f;
            burst = false;

        }
    }
}
