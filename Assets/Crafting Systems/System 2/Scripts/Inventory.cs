using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    private List<Items> itemList;

    public Inventory()
    {
        itemList = new List<Items>();

      //  AddItem(new Items { itemType = Items.ItemType.Head, amount = 1 });
       // AddItem(new Items { itemType = Items.ItemType.Arm, amount = 2 });
       // AddItem(new Items { itemScriptableObject.itemType, amount = 2 });

        Debug.Log(itemList.Count);
        
    }

    public void AddItem (Items items)
    {
       
        if (items.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach(Items inventoryItem in itemList)
            {
                if(inventoryItem.itemScriptableObject == items.itemScriptableObject)
                {
                    inventoryItem.amount += items.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(items);
            }
        }
        else
        {
            itemList.Add(items);
        }
    }

    public void RemoveItem(Items items)
    {
        if (items.IsStackable())
        {
            Items itemInInventory = null;
            foreach (Items inventoryItem in itemList)
            {
                if (inventoryItem.itemScriptableObject == items.itemScriptableObject)
                {
                    inventoryItem.amount -= items.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <=0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(items);
        }
    }

    public List<Items> GetItemList()
    {
        return itemList;
    }

}
