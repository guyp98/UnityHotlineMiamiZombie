using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BaseballBat",menuName ="Inventory Items/Weapons/Baseball Bat")]
public class BaseballBat : WeaponItem
{
    //public int damge;

    private void Awake()
    {
        this.itemType = ItemType.Weapon;
        this.itemName = "BaseballBat";
    }
}
