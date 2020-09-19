using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);
        if ( other.gameObject.CompareTag("Scone") ) {
            Debug.Log("HEY!!!");
            var ps = other.gameObject.GetComponent<ParticleSystem>();
            Debug.Log(ps.main.maxParticles);
            FireflyManager.instance.AddFireflies(ps.main.maxParticles);
            Destroy(other.gameObject);
        }

        Debug.Log("ouch");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x*speed, y*speed);
    }
}
