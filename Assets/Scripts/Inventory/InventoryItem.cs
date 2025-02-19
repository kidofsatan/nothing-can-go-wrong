using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Text _itemCount;

    public void SetInventoryItem(ItemData _itemData)
    {
        _itemImage.sprite = _itemData.icon;
    }


}
