using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Knife", menuName = "Inventory Items/Weapons/Knife")]
public class Knife : closeColdWepon
{
    //public int damge;

    private void Awake()
    {
        this.itemType = ItemType.Weapon;
        this.itemName = "Knife";
    }
   
}
