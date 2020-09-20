using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    private Vector2 moveVelocity;
    private Inventory inven;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inven = GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.tag);
    }

    void OnTriggerStay2D(Collider2D col) {
        //Artifact Collision Check
            if ( col.gameObject.CompareTag("Artifact") ) {
                var artifact = col.gameObject.GetComponent<Artifact>();

                //Debug.Log(Input.GetKey(KeyCode.E));
                //Debug.Log(artifact.hasBeenViewed);

                if (Input.GetKey(KeyCode.E) && !artifact.hasBeenViewed) {
                    artifact.hasBeenViewed = true;
                }
            }
        //Lamp Collision Check
            else if ( col.gameObject.CompareTag("Lamp") ) {

<<<<<<< HEAD
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
=======
            var hoard = col.gameObject.GetComponent<HoardManager>();

            if (Input.GetKeyDown(KeyCode.E) ) {
                // Get the flies
                GlobalFireflyCounter.instance.AddFireflies(hoard.count);
                Debug.Log($"Gained {hoard.count} Firefly");
                // edit the lights of the Lamp
                GlobalFireflyController.instance.Modify(hoard, 0);

            }else if (Input.GetKeyDown(KeyCode.Q)) {
                // Drop off flies
                int removeCount = GlobalFireflyCounter.instance.Count / 2;
                GlobalFireflyCounter.instance.RemoveFireflies(removeCount);
                
                Debug.Log($"Deposited {removeCount} Firefly ");

                // edit the lights of the Lamp
                GlobalFireflyController.instance.Modify(hoard, hoard.count + removeCount);
>>>>>>> 567f5020d0eb27be25e03566f7165852d8a7b061
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
        //Movement
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        
        //Inventory
        if (Input.GetKey(KeyCode.I))
        {
            if (inven.isOpen)
                inven.CloseInven();
            else 
                inven.OpenInven(); 
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);       
    }
}
