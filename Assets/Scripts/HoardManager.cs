using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HoardManager : MonoBehaviour {

    public GameObject fireflyPrefab;
    public int initialCount = 3;

    private List<GameObject> fireflies;
    private List<Light2D> lights;

    public List<Light2D> getLights() {
        return lights;
    }

    void Awake() {
        fireflies = new List<GameObject>();
        lights = new List<Light2D>();
    }

    void Start() {
        count = initialCount;
    }

    void DropOff() {

    }

    public int count{

        get {
            return fireflies.Count;
        }

        set {
            if (count == value){
            } else if (count < value) {
                // add new

                int addCount = value - count;
                for(int i=0; i < addCount; i ++) {
                    GameObject firefly = Instantiate(fireflyPrefab);
                    fireflies.Add(firefly);
                    firefly.GetComponent<FollowGameObject>().Switch(transform);
                    lights.Add( firefly.GetComponent<Light2D>() );
                }
            } else if (count > value) {
                // remove extra
                int removeCount = count - value;
                
                for(int i=0; i < removeCount; i ++) {
                    GameObject firefly = fireflies[i];
                    Destroy(firefly);
                }
                fireflies.RemoveRange(0, removeCount);
                lights.RemoveRange(0, removeCount);
            }
        }
    }
}
