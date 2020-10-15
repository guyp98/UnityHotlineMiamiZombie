using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
     public InventoryObject inventory;

    public int Y_start;
    public int X_start;
    public int X_Space_Between_Items;
    public int Y_Space_Between_Items;
    public int NumOfColumns;
    Dictionary<InventorySlot, GameObject> ItemDispaly = new Dictionary<InventorySlot, GameObject>();
    
    void Start()
    {
       CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateDisplay()
    {
        for (int i=0;i<inventory.Inventory.Count;i++)
        {
            var obj = Instantiate(inventory.Inventory[i].Item.shopSprite,Vector2.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.transform.Find("name").GetComponent<Text>().text= inventory.Inventory[i].Item.name;
            obj.transform.Find("Amount").GetComponent<Text>().text = inventory.Inventory[i].Amount.ToString();
        }
    }
    public Vector2 GetPosition(int i)
    {
        return new Vector2(X_start+( X_Space_Between_Items*(i%NumOfColumns)),Y_start+(-Y_Space_Between_Items*(i/NumOfColumns)));
    }
}
