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

        float x = Simplify(Input.GetAxisRaw("Horizontal"));
        float y = Simplify(Input.GetAxisRaw("Vertical"));
        Tilt(x, y);

        transform.position = Vector3.MoveTowards(transform.position, target + player.position, step);
    }

    float Simplify(float x) {
        if (x == 0.0) return x;
        return x / Mathf.Abs(x);
    }

    void Tilt(float x, float y) {
        if (x != 0 || y != 0) 
            target = new Vector3(x*offset, y*offset, 0);
    }

}
