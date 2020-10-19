using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{Weapon,Armor,Food}

public abstract class ItemObject : ScriptableObject
{
    public  string itemName;
    protected ItemType itemType;
    public Sprite playerSprite;
    public GameObject shopSprite;


    public abstract void attack();
    public abstract void SetOrigin(Vector3 origin);
    public abstract void SetAimDirection(Vector3 aimDirection);
   
}
