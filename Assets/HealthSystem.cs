using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    public int health;
    public int MinLimit;
    public int MaxLimit;

    private int LimitCorrecteur(int current)
    {
        int correctTo= current;
        if (current < MinLimit )
        {
            correctTo = MinLimit;
        }
        else if (current > MaxLimit)
        {
            correctTo = MaxLimit;
        }

        return correctTo;
    }
    public void addHealth(int amount)
    {
        health += amount;
        health = LimitCorrecteur(health);
    }
    public void SubHealth(int amount)
    {
        health -= amount;
        health = LimitCorrecteur(health);
    }
    private void ChangePlayerSpeed(int ChangeTo)
    {
        GetComponent<playerMovment>().moveSpeed = ChangeTo;
    }
}

