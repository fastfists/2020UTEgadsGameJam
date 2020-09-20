using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System.Security.Policy;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.InteropServices;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{

    Dictionary<int, Item> inventory = new Dictionary<int, Item>();
    private int currentKeyIndex = 1;
    Item item = new Item();
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] Transform inventoryPanel;
    [FormerlySerializedAs("inventoryPanelDO")] public RectTransform inventoryPanelDo;
    public int invenDisplacement;
    public bool isOpen=false;
    

    public void UpdateInventory(string title, string description, Sprite sprite)
    {
        item.title = title;
        item.description = description;
        item.sprite = sprite;
        inventory.Add(currentKeyIndex, item);
        currentKeyIndex++;
        Debug.Log(inventory.Count);
        MakeButtonPrefab(title);
        //CreateButton();
    }
    public void MakeButtonPrefab(string title)
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab, inventoryPanel.transform, false);
        button.GetComponentInChildren<TextMeshProUGUI>().text = title;
        //button.GetComponent<button>().onClick.addListener
        Debug.Log(button.transform.position.y);
    }
    public void OpenInven()
    {
        isOpen = true;
        inventoryPanelDo.DOAnchorPos(new Vector2(invenDisplacement,0), .50f);
    }
    public void CloseInven()
    {
        isOpen = false;
        inventoryPanelDo.DOAnchorPos(new Vector2(invenDisplacement*2, 0), .50f);
    }
}