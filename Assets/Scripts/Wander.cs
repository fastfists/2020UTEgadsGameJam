using UnityEngine;

public class Wander : MonoBehaviour
{
    public float fireFlySpeed;
    private float waitTime;
    public float startWaitTime;
    
    public Transform[] moveSpots;
    private int randomSpot;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, fireFlySpeed * Time.deltaTime);

        if (!(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)) return;
        if (waitTime <= 0)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
