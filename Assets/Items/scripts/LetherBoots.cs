using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LetherBoots", menuName = "Inventory Items/Armors/LetherBoots")]
public class LetherBoots : ItemObject
{

    public int Defens;

    private void Awake()
    {
        this.itemType = ItemType.Armor;
        this.name = "LetherBoots";
    }
}
