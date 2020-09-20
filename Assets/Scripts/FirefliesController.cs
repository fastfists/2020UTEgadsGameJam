using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FirefliesController : MonoBehaviour {
    // Start is called before the first frame update

    private Light2D flyLight;
    private HoardManager hoard;

    void Start() {
        flyLight = GetComponent<Light2D>();
        hoard = GetComponent<HoardManager>();
    }

    void Update() {
        UpdateFlies();
    }

    private void UpdateFlies() {
        int count = FireflyManager.instance.Count;
        GlobalFireflyController.instance.Modify(hoard, count);
    }
}
