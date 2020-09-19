using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalFireflyController : MonoBehaviour {
    // Start is called before the first frame update
    public static GlobalFireflyController instance;

    public float pointLightRadiusMax;
    public float pointLightRadiusMin;

    public float radiusRatio = 0.5f;

    public float pointLightIntensityMax;
    public float pointLightIntensityMin;

    void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    public void Modify(Light2D light, ParticleSystem ps, int count) {
        SetParticleSystem(ps, count);
        SetLight(light, count);
    }

    public void SetParticleSystem(ParticleSystem ps, int count) {
        var main = ps.main;
        main.maxParticles = count;
    }

    public void SetLight(Light2D light, int count) {
        int maxFireflies = FireflyManager.instance.maxFireflies;
        light.intensity = Map((float)count,
                0.0f, maxFireflies,
                pointLightIntensityMin, pointLightIntensityMax
                );

        float radius = Map(
                (float)count,
                0.0f, maxFireflies,
                pointLightRadiusMin, pointLightRadiusMax
                );
        light.pointLightOuterRadius = radius / 0.5f;

        light.pointLightInnerRadius = radius * 0.5f;
    }

    private static float Map(float s, float a1, float a2, float b1, float b2) {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

}
