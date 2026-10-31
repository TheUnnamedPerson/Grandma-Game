using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    
    public static PuzzleManager Instance { get; private set; }
    
    public InventoryPanel inventoryPanel;

    public ItemData[] inventoryItems;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (inventoryItems == null)
        {
            inventoryItems = new ItemData[5]; // Initialize with 5 slots
        }
    }

    public void CollectItem (ItemObject item)
    {
        if (item != null && item.itemData != null)
        {
            Debug.Log($"Collected item: {item.itemData.itemName} (ID: {item.itemData.id})");
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i] == null)
                {
                    inventoryItems[i] = item.itemData;
                    Debug.Log($"Item {item.itemData.itemName} added to inventory slot {i}.");
                    item.ItemCollected();
                    if (inventoryPanel != null)
                    {
                        inventoryPanel.UpdateInventoryUI();
                    }
                    else
                    {
                        Debug.LogWarning("InventoryPanel reference is null. Cannot update UI.");
                    }
                    return;
                }
            }
            
            Debug.LogWarning("Inventory is full. Cannot add item.");
        }
        else
        {
            Debug.LogError("Item or ItemData is null.");
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
