using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour {
    public float offset;
    public float speed;
    public Transform player;

    private Vector3 target;

    void Update() {
        float step = speed * Time.deltaTime;

        float x = simplify(Input.GetAxisRaw("Horizontal"));
        float y = simplify(Input.GetAxisRaw("Vertical"));
        tilt(x, y);

        transform.position = Vector3.MoveTowards(transform.position, target + player.position, step);
    }

    float simplify(float x) {
        if (x == 0.0) return x;
        return x / Mathf.Abs(x);
    }

    void tilt(float x, float y) {
        if (x != 0 || y != 0) 
            target = new Vector3(x*offset, y*offset, 0);
    }

}
