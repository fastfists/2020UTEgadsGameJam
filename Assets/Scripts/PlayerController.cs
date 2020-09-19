using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float speed;
    
    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.tag);
        if ( col.gameObject.CompareTag("Scone") ) {
            var ps = col.gameObject.GetComponent<ParticleSystem>();
            FireflyManager.instance.AddFireflies(ps.main.maxParticles);
            Destroy(col.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if ( col.gameObject.CompareTag("Artifact") ) {
            var artifact = col.gameObject.GetComponent<Artifact>();

            Debug.Log(Input.GetKey(KeyCode.E));
            Debug.Log(artifact.hasBeenViewed);

            if (Input.GetKey(KeyCode.E) && !artifact.hasBeenViewed) {
                artifact.hasBeenViewed = true;
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
