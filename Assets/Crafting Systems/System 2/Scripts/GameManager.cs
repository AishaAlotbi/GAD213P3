using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private ItemScriptableObject testItemScriptableObject;

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

    }

    private void Start()
    {

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        inventory.AddItem(new Items { itemScriptableObject = testItemScriptableObject, amount = 10 });


        CraftingSystem craftingSystem = new CraftingSystem();
    }
       
}
