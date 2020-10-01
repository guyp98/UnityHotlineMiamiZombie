using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BaseballBat",menuName ="Inventory Items/Weapons/Baseball Bat")]
public class BaseballBat : ItemObject
{
    public int damge;

    private void Awake()
    {
        this.itemType = ItemType.Weapon;
        this.itemName = "BaseballBat";
    }
}
