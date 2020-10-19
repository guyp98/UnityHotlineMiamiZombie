using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInHand : MonoBehaviour
{
    public Camera cam;
    public  GameObject weaponInHand;
    
    public void PutWeaponInHand(GameObject WeaponToPut)
    {
        
       weaponInHand = WeaponToPut;
       
    }

    public void Update()
    {
        numbersKeysToSelect();
    }

    private void numbersKeysToSelect()
    {
        if (Input.GetMouseButtonDown(0)) { Attack();  }
      // if (Input.GetKeyDown(KeyCode.Alpha2)) { Attack(); }
        //if (Input.GetKeyDown(KeyCode.Alpha3)) {  }

//        if (Input.GetKeyDown(KeyCode.Alpha4)) {  }
    }


    private void Attack()
    {
        Debug.Log("attack called");
        weaponInHand.GetComponent<TheItem>().theItem.SetAimDirection(cam.ScreenToWorldPoint(Input.mousePosition));
       weaponInHand.GetComponent<TheItem>().theItem.SetOrigin(Vector3.zero);
       weaponInHand.GetComponent<TheItem>().theItem.attack();
    }
    
}
