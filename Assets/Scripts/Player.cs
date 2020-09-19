using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int horizontalSpeed;
    public int verticalSpeed;
    private Collider2D collider;
    private bool isPaused;
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.position += Vector3.right * horizontalSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
        }
        if (collider)
            OnTriggerEnter2D(collider);

        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Artifact")
        {
            this.collider = collider;
            if (Input.GetKey(KeyCode.E)&& collider.gameObject.GetComponent<Artifact>().hasBeenViewed==false)
            {
                collider.gameObject.GetComponent<Artifact>().hasBeenViewed = true;
                Debug.Log("Player hit trigger");
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Artifact")
        {
            this.collider = null;
        }
    }

}
