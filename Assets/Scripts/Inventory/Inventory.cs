using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu; // ������ ���� � ���� ���������
    public GameObject inventoryItemPrefab; // ������ ������
    public Transform itemsParent; // ������������ ������ ��� �����
    public int numberOfSlots = 20; // ������������ ���������� �����

    // ������� ����������
    public TextMeshProUGUI ammoText; // ����������� TextMeshProUGUI ��� UI ������
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

    // ���������� ��������� ��� ������
    void OnApplicationQuit()
    {
       // SaveManager.SaveInventory(this);
    }


    //�������� ����� ��� ��������

    public bool HasSpaceForItem(InventoryItem newItem, int quantity)
    {
        return true;
    }

    // ���������� �������� � ���������
    public void AddItem(InventoryItem newItem, int quantity)
    {
       
    }


    // ����� ������������� ��������, ������� � ���������� ������������ �����
    public void UseAmmo(int amount)
    {
        
    }

    // ������� ��������
    private void UpdateAmmoCount()
    {
        
    }

    //�������� �������� �� ���������
    public void RemoveItemFromSlot(InventoryItem slot)
    {
       
    }

    // ���������� ���������
    private void RearrangeInventory()
    {
        
    }

    // ���������� ����������� �������� �� UI
    private void UpdateAmmoUI()
    {
        ammoText.text = ammoCount.ToString();
    }

    // ����� ��� ������ �������� ���������
    public void OpenInventoryMenu()
    {
        inventoryMenu.SetActive(true);
    }

    // ����� ��� ������ �������� ���������
    public void CloseInventoryMenu()
    {
        inventoryMenu.SetActive(false);
    }



}