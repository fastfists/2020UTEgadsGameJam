using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FirefliesController : MonoBehaviour {
    // Start is called before the first frame update

    public float lightOffset = 0.2f;

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
        SetLight(count);
        SetParticles(count);
    }

    private void SetParticles(int count) {
        var main = particles.main;
        main.maxParticles = count;
    }

    private void SetLight(int count) {
        int maxFireflies = FireflyManager.instance.maxFireflies;

        flyLight.intensity = Map((float)count,
                0.0f, maxFireflies,
                pointLightIntensityMin, pointLightIntensityMax
                );

        float radius = Map(
                (float)count,
                0.0f, maxFireflies,
                pointLightRadiusMin, pointLightRadiusMax
                );

        flyLight.pointLightOuterRadius = radius / 0.5f;

        flyLight.pointLightInnerRadius = radius * 0.5f;
    }

    private float Map(float s, float a1, float a2, float b1, float b2) {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

}
