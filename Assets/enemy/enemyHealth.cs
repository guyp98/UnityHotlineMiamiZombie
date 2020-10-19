using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float MaxLimit;
    public float health;

    public void Gothit(float damge)
    {
        health -= damge;
        health = LimitCorrecteur(health);
        Debug.Log("enemy got hit " + damge +" health");
    }

    private float LimitCorrecteur(float current)
    {
        float correctTo = current;
        if (current < 0)
        {
            correctTo = 0;
        }
        else if (current > MaxLimit)
        {
            correctTo = MaxLimit;
        }

        return correctTo;
    }
}
