using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyManager : MonoBehaviour
{
    public static FireflyManager instance;

    public int initialFirefliesCount = 5;
    public int maxFireflies = 30;

    public int Count {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            Count = initialFirefliesCount;
        }
    }

    public void AddFireflies(int incr) {
        Debug.Log(incr);
        if (Count < maxFireflies) {
            Count += incr;
        }
    }

    public void RemoveFireflies(int incr) {
        if (Count > 0) {
            Count -= incr;
        }
    }
}
