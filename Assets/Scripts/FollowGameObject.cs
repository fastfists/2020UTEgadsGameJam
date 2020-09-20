using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Vector2 center;
    public float rotateSpeed;

    private float angle = 0;

    void Start() {
        center = target.position;
        angle = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update() {
        center = target.position;

        angle += rotateSpeed*Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));

        transform.position = center + offset;
    }

    public void Switch(Transform newTarget) {
        target = newTarget;
    }

}
