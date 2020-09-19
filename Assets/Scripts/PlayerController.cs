using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float speed;
    
    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.tag);
    }

    void OnTriggerStay2D(Collider2D col) {
        if ( col.gameObject.CompareTag("Artifact") ) {
            var artifact = col.gameObject.GetComponent<Artifact>();

            Debug.Log(Input.GetKey(KeyCode.E));
            Debug.Log(artifact.hasBeenViewed);

            if (Input.GetKeyDown(KeyCode.E) && !artifact.hasBeenViewed) {
                artifact.hasBeenViewed = true;
            }
        }
        else if ( col.gameObject.CompareTag("Scone") ) {

            var ps = col.gameObject.GetComponent<ParticleSystem>();
            var mainPs = ps.main;
            var light = col.gameObject.GetComponent<Light2D>();

            if (Input.GetKeyDown(KeyCode.E) ) {
                // Get the flies
                FireflyManager.instance.AddFireflies(mainPs.maxParticles);

                // edit the lights of the Lamp
                GlobalFireflyController.instance.Modify(light, ps, 0);

            }else if (Input.GetKey(KeyCode.Q)) {
                // Drop off flies
                int removeCount = FireflyManager.instance.count / 2;
                FireflyManager.instance.RemoveFireflies(removeCount);

                Debug.Log("Trade " + removeCount);

                // edit the lights of the Lamp
                GlobalFireflyController.instance.Modify(light, ps, mainPs.maxParticles + removeCount);
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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);       
    }
}
