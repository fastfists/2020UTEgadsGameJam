using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSetter : MonoBehaviour
{
    private GameObject[] lamps;
    private bool hasUpdated;

    void Start()
    {
        lamps = GameObject.FindGameObjectsWithTag("Lamp");
        hasUpdated = false;
    }

    void Update() {
        if (!hasUpdated) {
            foreach (var lamp in lamps) {
                var light = lamp.GetComponent<Light2D>();
                var hoard = lamp.GetComponent<HoardManager>();

                GlobalFireflyController.instance.Modify(hoard, hoard.count);
            }
            hasUpdated = true;
        }
    }
}
