using System.Collections;
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

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasBeenViewed == true)
        {
            artifact.SetActive(false);
            titlePro.text = title;
            descriptionPro.text = description;
            image.sprite = spriteRenderer.sprite;
            image.color = spriteRenderer.color;
            panel.SetActive(true);
            GameObject.FindGameObjectWithTag("Pause").GetComponent<MainMenu>().Pause();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().UpdateInventory(title, description, spriteRenderer.sprite);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Debug.Log(collider.tag);
            pressE.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
           // Debug.Log(collider.tag);
            pressE.SetActive(false);
        }
    }
}
