using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemScriptableObjects")]
public class ItemScriptableObject : ScriptableObject
{
    public Items.ItemType itemType;
    public string itemName;
    public Sprite itemSprite;

}
