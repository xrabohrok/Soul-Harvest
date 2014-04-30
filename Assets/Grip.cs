using UnityEngine;
using System.Collections;

public class Grip : MonoBehaviour {

    bool jumping = false;

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

                if(Input.GetButtonDown("Jump") && !jumping)
                {
                    jumping = true;
                    this.renderer.enabled = false;

                    killSelf(meat);
                    createTarget(meat);

                    meat.drained();

                    createJumpAnim(meat);

                    GameObject.Destroy(this.gameObject);
                }
            }
        }
	}

    private void killSelf(Possesable meat)
    {
        ((jumper)GameObject.FindObjectOfType<jumper>()).explode();
    }

    private void die()
    {
        this.renderer.enabled = false;
        GameObject.Destroy(this.gameObject);
    }

    private void createJumpAnim(Possesable meat)
    {
        GameObject skull = GameObject.Instantiate(Resources.Load("skull")) as GameObject;
        skull.GetComponent<spiritEffect>().go(this.transform, meat.transform);
    }

    private void createTarget(Possesable meat)
    {
        GameObject home = GameObject.Instantiate(Resources.Load("JumperPrefab")) as GameObject;
        home.transform.position = meat.gameObject.transform.position;
    }
}
