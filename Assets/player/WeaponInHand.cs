using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInHand : MonoBehaviour
{

    public GameObject weaponInHand;

    public void PutWeaponInHand(GameObject WeaponToPut)
    {
        
        weaponInHand = WeaponToPut;
        GetComponent<SpriteRenderer>().sprite = WeaponToPut.GetComponent<TheItem>().item.playerSprite;
    }


    public void Attack()
    {

    }
    
}
