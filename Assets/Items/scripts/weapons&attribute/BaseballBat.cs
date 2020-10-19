using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BaseballBat",menuName ="Inventory Items/Weapons/Baseball Bat")]
public class BaseballBat : closeColdWepon
{
   // public int damge;

    private void Awake()
    {
        this.itemType = ItemType.Weapon;
        this.itemName = "BaseballBat";
    }
    public void Attack()
    {
        attack();
    }
}
