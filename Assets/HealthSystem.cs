using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    public int health;
    private int MinLimit=0;//allways zero .because  a bug fix 
    public int MaxLimit;
    public GameObject Dispaly;


    private void Awake()
    {
        health = LimitCorrecteur(health);
        MinLimit = 0;
        
        Dispaly.GetComponent<HealthDisplay>().BuildHearts(health,(MaxLimit-health));
    }

   

    public void addHealth(int amount)
    {
        if (amount<0) { throw new ArgumentOutOfRangeException(); }
        health += amount;
        health = LimitCorrecteur(health);
        ChangePlayerSpeed();
        Dispaly.GetComponent<HealthDisplay>().IncreaseFullHearts(1);
    }
    
    public void SubHealth(int amount)
    {
        if (amount < 0) { throw new ArgumentOutOfRangeException(); }
        health -= amount;
        health = LimitCorrecteur(health);
        ChangePlayerSpeed();
        Dispaly.GetComponent<HealthDisplay>().DecreaseFullHearts(amount);
    }

    public void NewMaxLimit(int amount)
    {
        if (amount >= 0)
        {
            if (MaxLimit + amount > Dispaly.GetComponent<HealthDisplay>().AllHearts.Count)
            {
                throw new ArgumentException("not enough hearts to desplay in list");
            }
            else
            {
                MaxLimit += amount;
                Dispaly.GetComponent<HealthDisplay>().IncreasePool(amount);
            }
        }
        else 
        {
            MaxLimit = MaxLimit + amount;
            if (MaxLimit < 0) { MaxLimit = 0; }
            health = LimitCorrecteur(health);
            Dispaly.GetComponent<HealthDisplay>().DecreasePool(-amount);
        }

    }

    private int LimitCorrecteur(int current)
    {
        int correctTo = current;
        if (current < MinLimit)
        {
            correctTo = MinLimit;
        }
        else if (current > MaxLimit)
        {
            correctTo = MaxLimit;
        }

        return correctTo;
    }
    private void ChangePlayerSpeed()
    {
        Debug.Log(health / (MaxLimit - MinLimit));
        float presenteg = (float)((float)health / (float)(MaxLimit - MinLimit)) * 1.4f;
        GetComponent<playerMovment>().moveSpeed = presenteg * 8;
    }
   
    
    
    //debug under me
    private void Update()
    {
        numbersKeysToSelect();
        
    }


    private void numbersKeysToSelect()
    {
        if ( Input.GetKeyDown(KeyCode.Alpha1) ) { addHealth(1);}
        if ( Input.GetKeyDown(KeyCode.Alpha2) ) { SubHealth(1);}
        if ( Input.GetKeyDown(KeyCode.Alpha3)) { NewMaxLimit(1);}
       
        if ( Input.GetKeyDown(KeyCode.Alpha4) ){NewMaxLimit(-1);}
    }
}

