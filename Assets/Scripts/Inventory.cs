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

public class Inventory : MonoBehaviour
{

    List<Item> inventory = new List<Item>();
    List<GameObject> buttons = new List<GameObject>();

    Item item = new Item();
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform inventoryPanel;

    public RectTransform inventoryPanelDO;
    public int invenDisplacement;
    public bool isOpen=false;
    public float canvasHeight;

    void Start() 
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateInventory(string title, string description, Sprite sprite)
    {
        item.title = title;
        item.description = description;
        item.sprite = sprite;
        inventory.Add(item);

        MakeButtonPrefab(title);


        //CreateButton();

        for (int i = 0; i < buttons.Count; i++) {
            var button = buttons[i];
            button.transform.SetParent(inventoryPanel.transform, false);
            button.transform.position += new Vector3(0, i*canvasHeight / buttons.Count, 0);
        }

    }

    public void MakeButtonPrefab(string title)
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.GetComponentInChildren<TextMeshProUGUI>().text = title;
        //button.GetComponent<button>().onClick.addListener
        button.transform.SetParent(inventoryPanel.transform, false);
        buttons.Add(button);
    }

    public void OpenInven()
    {
        
        isOpen = true;
        inventoryPanelDO.DOAnchorPos(new Vector2(invenDisplacement,0), .50f);

    }

    public void CloseInven()
    {
        isOpen = false;
        inventoryPanelDO.DOAnchorPos(new Vector2(invenDisplacement*2, 0), .50f);
    }
}
