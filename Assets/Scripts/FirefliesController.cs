using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FirefliesController : MonoBehaviour {
    // Start is called before the first frame update

    public float pointLightRadiusMax;
    public float pointLightRadiusMin;

    public float radiusRatio = 0.5f;

    public float pointLightIntensityMax;
    public float pointLightIntensityMin;

    private Light2D flyLight;
    private ParticleSystem particles;

    void Start() {
        flyLight = GetComponent<Light2D>();
        particles = GetComponent<ParticleSystem>();
    }

    void Update() {
        UpdateFlies();
    }

    private void UpdateFlies() {
        int count = FireflyManager.instance.count;
        GlobalFireflyController.instance.Modify(flyLight, particles, count);
    }
}
