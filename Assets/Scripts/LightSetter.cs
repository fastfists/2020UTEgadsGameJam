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
        lamps = GameObject.FindGameObjectsWithTag("Scone");
        hasUpdated = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || !hasUpdated) {
            foreach (var lamp in lamps) {
                Debug.Log("Oh yea!!!");
                var light = lamp.GetComponent<Light2D>();
                var ps = lamp.GetComponent<ParticleSystem>();
                var main = ps.main;

                GlobalFireflyController.instance.Modify(light, ps, main.maxParticles);
            }
            hasUpdated = true;
        }
    }
}
