
using System;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

 

    // Update is called once per frame
    void Update()
    {
        int preViousSelectedWeapon = selectedWeapon;

        ScrollToSelect();
        numbersKeysToSelect();

        if (preViousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }

    }
    private void numbersKeysToSelect()//chaing "selectedWeapon" number with the numbers Keys
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))                              { selectedWeapon = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2) { selectedWeapon = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3) { selectedWeapon = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4) { selectedWeapon = 3; }
    }
    private void ScrollToSelect()// chaing "selectedWeapon" number with the wheel
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;

        }
    }
    private void selectWeapon()// use "selectedWeapon" to enable only one weapon from  WeaponSwitching childrens
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.parent.GetComponentInParent<WeaponInHand>().PutWeaponInHand(weapon.gameObject);
                weapon.parent.GetComponentInParent<SpriteRenderer>().sprite = weapon.GetComponent<TheItem>().item.playerSprite;
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
