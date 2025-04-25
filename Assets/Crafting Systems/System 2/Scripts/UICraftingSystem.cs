using UnityEngine;

public class UICraftingSystem : MonoBehaviour
{
    private Transform[,] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;

    [SerializeField] private Transform itemPrefab;

    private void Awake()
    {

        Transform gridContainer = transform.Find("gridContainer");
        itemContainer = transform.Find("itemContainer");
        slotTransformArray = new Transform[CraftingSystem.gridSize, CraftingSystem.gridSize];

        for (int x = 0; x < CraftingSystem.gridSize; x++)
        {
            for (int y = 0; y < CraftingSystem.gridSize; y++)
            {
                slotTransformArray[x, y] = gridContainer.Find("grid_" + x + "_" + y);
            }
        }

        outputSlotTransform = transform.Find("outputSlot");
    }

    private void CreateItem(int x, int y, Items item)
    {
        Transform itemTransform = Instantiate(itemPrefab, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
       // itemTransform.GetComponent<Items>().GetSprite(item);
    }
}
