﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.tag);
    }

    void OnTriggerStay2D(Collider2D col) {
        if ( col.gameObject.CompareTag("Artifact") ) {
            var artifact = col.gameObject.GetComponent<Artifact>();

            //Debug.Log(Input.GetKey(KeyCode.E));
            //Debug.Log(artifact.hasBeenViewed);

            if (Input.GetKey(KeyCode.E) && !artifact.hasBeenViewed) {
                artifact.hasBeenViewed = true;
            }
        }
        else if ( col.gameObject.CompareTag("Lamp") ) {

            var ps = col.gameObject.GetComponent<ParticleSystem>();
            var mainPs = ps.main;
            var light2D = col.gameObject.GetComponent<Light2D>();

            if (Input.GetKeyDown(KeyCode.E) ) {
                // Get the flies
                FireflyManager.instance.AddFireflies(mainPs.maxParticles);
                Debug.Log($"Gained {mainPs.maxParticles} Firefly");
                // edit the lights of the Lamp
                GlobalFireflyController.instance.Modify(light2D, ps, 0);

            }else if (Input.GetKeyDown(KeyCode.Q)) {
                // Drop off flies
                int removeCount = FireflyManager.instance.Count / 2;
                FireflyManager.instance.RemoveFireflies(removeCount);
                
                Debug.Log($"Deposited {removeCount} Firefly ");

                // edit the lights of the Lamp
                GlobalFireflyController.instance.Modify(light2D, ps, mainPs.maxParticles + removeCount);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if ( col.gameObject.CompareTag("Artifact") ) {
            var artifact = col.gameObject.GetComponent<Artifact>();
            if (artifact.hasBeenViewed){
                Destroy(col.gameObject);
            }
        }
    }
    
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);       
    }
}
