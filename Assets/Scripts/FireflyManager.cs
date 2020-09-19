using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyManager : MonoBehaviour
{
    public static FireflyManager instance;

    public int initialFirefliesCount = 5;
    public int maxFireflies = 30;

    public int count {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            count = initialFirefliesCount;
        }
    }

    public void AddFireflies(int incr) {
        Debug.Log("fdsfsdalf");
        if (count < maxFireflies) {
            count += incr;
        }
        Debug.Log(count);
    }

    public void RemoveFireflies(int incr) {
        if (count > 0) {
            count -= incr;
        }
    }
}
