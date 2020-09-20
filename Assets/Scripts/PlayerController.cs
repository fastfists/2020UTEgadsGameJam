using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Inventory inven;
    public Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inven = GetComponent<Inventory>();
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

            var hoard = col.gameObject.GetComponent<HoardManager>();

            if (Input.GetKey(KeyCode.E) ) {
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
            }
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if ( col.gameObject.CompareTag("Artifact") ) {
            var artifact = col.gameObject.GetComponent<Artifact>();
            if (artifact.hasBeenViewed){
                col.gameObject.SetActive(false);
            }
        }
    }
    
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput.normalized * speed;
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
