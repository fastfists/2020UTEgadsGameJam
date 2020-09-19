﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class Inventory : MonoBehaviour
{

    Dictionary<int, Item> inventory = new Dictionary<int, Item>();
    int currentKeyIndex = 1;
    Item item = new Item();
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform inventoryPanel;
    int yChange = 0;
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
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.GetComponentInChildren<TextMeshProUGUI>().text = title;
        //button.GetComponent<button>().onClick.addListener
        button.transform.SetParent(inventoryPanel.transform, false);
       // button.transform.position.y += yChange;
    }
    /*public static void CreateButton()
    {
        var button = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(inventoryPanel.transform);
        //rectTransform.anchorMax = cornerTopRight;
        //rectTransform.anchorMin = cornerBottomLeft;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        
    }*/
}