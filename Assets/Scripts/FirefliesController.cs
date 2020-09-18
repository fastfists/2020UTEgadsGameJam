using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FirefliesController : MonoBehaviour {
    // Start is called before the first frame update
    public int initialFirefliesCount = 0;
    public GameObject fireflies;

    public float lightOffset = 0.2f;
    public int maxFireflies = 30;

    private Light2D flyLight;
    private ParticleSystem particles;
    private float intensity;
    private int count;

    void Start() {
        flyLight = fireflies.GetComponent<Light2D>();
        particles = fireflies.GetComponent<ParticleSystem>();
        count = initialFirefliesCount;
        UpdateFlies();
    }

    void Update() {
        flyLight.intensity = intensity;
        addFireflies(1);
    }

    public void addFireflies(int count) {
        if (this.count < maxFireflies) {
            this.count += count;
            UpdateFlies();
        }else {
            Debug.Log("Im full damn nigg");
        }
    }

    public void removeFireflies(int count) {
        if (this.count > 0) {
            this.count -= count;
            UpdateFlies();
        }
    }
        
    private void UpdateFlies() {
        SetLight();
        SetParticles();
    }

    private void SetParticles() {
    }

    private void SetLight() {
        intensity = Map((float)count, 0.0f, maxFireflies, 0.2f, 0.7f);
        flyLight.pointLightOuterRadius = Map((float)count, 0.0f, maxFireflies, 4.6f, 12.17f);
        flyLight.pointLightInnerRadius = Map((float)count, 0.0f, maxFireflies, 2.43f, 8.7f);
    }

    private float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
}
