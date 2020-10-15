﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log(other.name);
        var item = other.GetComponent<TheItem>().item;
        if (item != null)
        {

            this.GetComponentInChildren<Inventory>().PlayerInventory.AddItem(1,item);
            //this.GetComponentInChildren<Inventory>().PlayerInventory.
            // PlayerInventory.AddItem(1, item);
            Destroy(other.gameObject);
        }
        
    }
}
