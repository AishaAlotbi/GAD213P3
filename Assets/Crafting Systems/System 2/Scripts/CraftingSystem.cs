using UnityEngine;

public class CraftingSystem 
{
    public const int gridSize = 3;
    private Items[,] itemArray;
    private ItemScriptableObject itemScriptableObject;
    public CraftingSystem()
    {
        itemArray = new Items[gridSize, gridSize];
    }

    private bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    private Items GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    private void SetItem(Items item, int x, int y)
    {
        itemArray[x, y] = item;
    }

    private void IncreaseItemAmmount(int x, int y)
    {
        GetItem(x, y).amount++;
    }

    private void DecreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount--;
    }

    private void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    private bool TryAddItem(Items item, int x, int y)
    {
        if(IsEmpty(x, y))
        {
            SetItem(item, x, y); 
            return true;
        }
        else
        {
            if(itemScriptableObject.itemType == GetItem(x, y).itemScriptableObject.itemType)
            {
                IncreaseItemAmmount(x,y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
