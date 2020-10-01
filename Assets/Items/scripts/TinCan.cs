using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tin Can", menuName = "Inventory Items/Foods/Tin can")]

public class TinCan : ItemObject
{

    public int Energy;

    private void Awake()
    {
        this.itemType = ItemType.Food;
        this.itemName = "Tin can";
    }
   
}
