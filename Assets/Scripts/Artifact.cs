using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Artifact : MonoBehaviour
{
    public GameObject panel;
    public GameObject artifact;
    public string title;
    public string description;
    public GameObject pressE;
    public bool hasBeenViewed = false;
    public TextMeshProUGUI titlePro;
    public TextMeshProUGUI descriptionPro;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasBeenViewed == true)
        {
            artifact.SetActive(false);
            titlePro.text = title;
            descriptionPro.text = description;
            panel.SetActive(true);
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
