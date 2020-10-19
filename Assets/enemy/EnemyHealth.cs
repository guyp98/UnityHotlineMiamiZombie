using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{



    public int health;
     
    public int MaxLimit;
   


    private void Awake()
    {
        health = LimitCorrecteur(health);
    }



    public void addHealth(int amount)
    {
        if (amount < 0) { throw new ArgumentOutOfRangeException(); }
        health += amount;
        health = LimitCorrecteur(health);
        
       
    }

    public void SubHealth(int amount)
    {
        if (amount < 0) { throw new ArgumentOutOfRangeException(); }
        health -= amount;
        health = LimitCorrecteur(health);
        
        IsEnemyDead();
    }

    public void AddOrSubMaxLimit(int amount)
    {
        if (amount >= 0)
        {
           
                MaxLimit += amount;
                
            
        }
        else
        {
            MaxLimit = MaxLimit + amount;//amount is negative
            if (MaxLimit < 0) { MaxLimit = 0; }
            health = LimitCorrecteur(health);
            
            IsEnemyDead();
        }
        

    }

    private int LimitCorrecteur(int current)
    {
        int correctTo = current;
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
   

    
    private void IsEnemyDead()
    {
        if (health == 0)
        {
            Debug.Log("Enemy Dead");
            
            
        }
    }

    
}
