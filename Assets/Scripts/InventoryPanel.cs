using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    private Image[] slotImages;

    void Awake()
    {
        if (slotImages == null || slotImages.Length == 0)
        {
            slotImages = GetComponentsInChildren<Image>();
        }

        PuzzleManager.Instance.inventoryPanel = this;

        UpdateInventoryUI();
    }

    private void OnValidate()
    {
        if (slotImages == null || slotImages.Length == 0)
        {
            slotImages = new Image[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                Image img = transform.GetChild(i).GetChild(0).GetComponent<Image>();
                if (img != null)
                {
                    slotImages[i] = img;
                }
                else
                {
                    Debug.LogWarning($"No Image component found in child {i} of {transform.GetChild(i).name}. Please ensure each slot has an Image component.");
                }
            }

            for (int i = 0; i < slotImages.Length; i++)
            {
                slotImages[i].sprite = null;
                slotImages[i].enabled = false;
            }
        }
        
    }

    public void UpdateInventoryUI()
    {
        PuzzleManager pm = PuzzleManager.Instance;

        if (pm == null)
        {
            Debug.LogError("PuzzleManager instance is null.");
            return;
        }

        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < pm.inventoryItems.Length && pm.inventoryItems[i] != null)
            {
                slotImages[i].sprite = pm.inventoryItems[i].sprite;
                slotImages[i].enabled = true;
            }
            else
            {
                slotImages[i].sprite = null;
                slotImages[i].enabled = false;
            }
        }
    }
}
