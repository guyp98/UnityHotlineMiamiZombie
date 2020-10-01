using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory System/Defult Inventory")]
public class InventoryObject : ScriptableObject
{
    
    public int maxInSlot;
    public List<InventorySlot> Inventory ;

  /*  private void Awake()
    {
        
        maxInSlot = 100;
        Inventory = new List<InventorySlot>();
       
    }
    */
    public InventoryObject(int maxInSlot)
    {
        
        this.maxInSlot = maxInSlot;
    }
    public void AddItem(int Amount,ItemObject NewItem)//add to free space in inventory
    {
        List<InventorySlot> MachItems=Inventory.FindAll(x => x.Item.name.Equals(NewItem.name) );
        
        if (MachItems.Count == 0 || MachItems.TrueForAll(x => x.Amount >= maxInSlot))
        {
          //  Debug.Log(MachItems.Count);
            InventorySlot newSlot = new InventorySlot(Amount, NewItem);
            Inventory.Add(newSlot);
        }
        else
        {
            try
            {
                MachItems.Find(x => x.Amount < maxInSlot).AddItem(NewItem,Amount);
            }
            catch (ArgumentException)
            {
                Debug.Log("something went wrong");
            }
        }
    }
    public void InsertItem(int Amunt, ItemObject NewItem,InventorySlot SelectedSlot)//insert to spacific slot in inventory
    {
        if (SelectedSlot == null)
        {
            Debug.Log("cant insert to null");
        }
        else if (SelectedSlot.Amount >= maxInSlot)
        {
            Debug.Log("cant inset to full slot");
        }
        else
        {
            SelectedSlot.AddItem(NewItem, Amunt);
        }
    }

}
[System.Serializable]
public class InventorySlot
{
    
    public ItemObject item;
    public int amount;
    

    public ItemObject Item { get => item;  }
    public int Amount { get => amount;  }

    public InventorySlot(int amount)
    {
        this.amount = amount;
    }
    public InventorySlot(int amount,ItemObject newItem)
    {
        this.amount = amount;
        this.item = newItem;
    }

    public void AddItem(ItemObject item,int Amount)
    {
        if (this.item == null)
        {
            this.item = item;
            this.amount = Amount;
        }

        if (this.item.name.Equals(item.name))
        {
            this.amount += Amount;
        }
        else
        {
            Debug.Log(item.name+" is not the same name of the item you are tring to add "+ this.item.name);
        }
    }
    public void SubItem(int Amount)
    {
        if (this.item == null)
        {
            Debug.Log("cant subtract from empty slot");
            this.amount = 0;
        }
        int newVal = this.amount - Amount;
        if (newVal < 0)
        {
            newVal = 0;
            item = null;
        }

    }
    public void Clear()
    {
        item = null;
        amount = 0;
    }
} 
