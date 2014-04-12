using UnityEngine;
using System.Collections;

public class Grip : MonoBehaviour {

    bool touching = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        var DeadSet = GameObject.FindObjectsOfType<Possesable>();

        foreach (var meat in DeadSet)
        {
            if(this.renderer.bounds.Intersects(meat.renderer.bounds))
            {
                meat.inSight();
            }
        }
	}
}
