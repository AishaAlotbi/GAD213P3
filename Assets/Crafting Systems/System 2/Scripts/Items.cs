using UnityEngine;

public class Items
{
    public enum ItemType
    {
        Leg,
        Arm,
        Head,
        Torso,
    }

    public ItemScriptableObject itemScriptableObject;
    public int amount;

    public Sprite GetSprite()
    {
        return itemScriptableObject.itemSprite;
    }
    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {

            default:
                case ItemType.Leg: return ItemAssets.Instance.legSprite;
                case ItemType.Head: return ItemAssets.Instance.headSprite;
                case ItemType.Torso: return ItemAssets.Instance.torsoSprite;
                case ItemType.Arm: return ItemAssets.Instance.armSprite;


        }
    }

    public override string ToString()
    {
        return itemScriptableObject.itemName;
    }
    
        public bool IsStackable()
        {
            switch(itemScriptableObject.itemType)
            {
                default:
                    //Stackable Items
                case ItemType.Leg:
                case ItemType.Arm:
                    return true;

                    //Non-Stackable Items
                case ItemType.Head: 
                case ItemType.Torso:
                    return false;

            }
        }
    
}
