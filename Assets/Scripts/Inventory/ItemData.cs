using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "Inventory/Inventory Item", order = 1)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
}
