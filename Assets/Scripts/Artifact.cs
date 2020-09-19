﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;

public class Artifact : MonoBehaviour
{
    public GameObject panel;
    public GameObject artifact;
    public string title;
    public string description;
    public GameObject pressE;
    public TextMeshProUGUI titlePro;
    public TextMeshProUGUI descriptionPro;
    public Image image;
    public bool hasBeenViewed = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasBeenViewed == true)
        {
            artifact.SetActive(false);
            titlePro.text = title;
            descriptionPro.text = description;
            image.sprite = artifact.GetComponent<SpriteRenderer>().sprite;
            image.color = artifact.GetComponent<SpriteRenderer>().color;
            panel.SetActive(true);
            GameObject.FindGameObjectWithTag("Pause").GetComponent<MainMenu>().Pause();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log(collider.tag);
            pressE.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log(collider.tag);
            pressE.SetActive(false);
        }
    }
}
