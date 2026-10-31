using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData itemData;

    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component is missing on the GameObject.");
            return;
        }

        if (itemData != null)
        {
            spriteRenderer.sprite = itemData.sprite;
        }
        else
        {
            Debug.LogError("ItemData is not assigned.");
        }

    }

    private void OnValidate()
    {
        SpriteRenderer sr = (spriteRenderer != null) ? spriteRenderer : GetComponent<SpriteRenderer>();
        if (itemData != null && sr != null)
        {
            sr.sprite = itemData.sprite;
        }
        else if (itemData == null)
        {
            sr.sprite = null; // Clear the sprite if itemData is null
        }
    }

    private void OnMouseDown()
    {
        if (itemData != null)
        {
            Debug.Log($"Item clicked: {itemData.itemName} (ID: {itemData.id})");
            PuzzleManager.Instance.CollectItem(this);
        }
        else
        {
            Debug.LogError("ItemData is not assigned.");
        }
    }

    public void ItemCollected()
    {
        // Optionally, you can add logic here to disable or destroy the item after collection
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
