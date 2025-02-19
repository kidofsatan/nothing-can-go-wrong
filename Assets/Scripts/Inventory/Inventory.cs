using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu; // Префаб окна с меню инвентаря
    public GameObject inventoryItemPrefab; // Префаб ячейки
    public Transform itemsParent; // Родительский объект для ячеек
    public int numberOfSlots = 20; // Максимальное количество ячеек

    // Считаем боеприпасы
    public TextMeshProUGUI ammoText; // Используйте TextMeshProUGUI для UI текста
    public int ammoCount;

    [SerializeField]private List<InventoryItem> slots = new List<InventoryItem>();


    void Start()
    {
        SetPlayerInventory();
    }

    public void SetPlayerInventory()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            Instantiate(inventoryItemPrefab, itemsParent);
        }
    }

    // сохранение инвентаря при выходе
    void OnApplicationQuit()
    {
       // SaveManager.SaveInventory(this);
    }


    //проверка места для предмета

    public bool HasSpaceForItem(InventoryItem newItem, int quantity)
    {
        return true;
    }

    // добавление предмета в инвентарь
    public void AddItem(InventoryItem newItem, int quantity)
    {
       
    }


    // метод использования патронов, начиная с последнего добавленного слота
    public void UseAmmo(int amount)
    {
        
    }

    // счетчик патронов
    private void UpdateAmmoCount()
    {
        
    }

    //удаление премдета из инвентаря
    public void RemoveItemFromSlot(InventoryItem slot)
    {
       
    }

    // сортировка инвентаря
    private void RearrangeInventory()
    {
        
    }

    // обновление отображения патронов на UI
    private void UpdateAmmoUI()
    {
        ammoText.text = ammoCount.ToString();
    }

    // метод для кнопки открытия инвентаря
    public void OpenInventoryMenu()
    {
        inventoryMenu.SetActive(true);
    }

    // метод для кнопки закрытия инвентаря
    public void CloseInventoryMenu()
    {
        inventoryMenu.SetActive(false);
    }



}