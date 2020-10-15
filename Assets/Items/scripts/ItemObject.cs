using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{Weapon,Armor,Food}

public abstract class ItemObject : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite playerSprite;
    public GameObject shopSprite;



}
