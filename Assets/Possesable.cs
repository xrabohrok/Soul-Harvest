using UnityEngine;
using System.Collections;

public class Possesable : MonoBehaviour {

    public Transform highlightSprite;

    float inView;
    float wanderTime;
    public float lit = .2f;
    public float takeTime = .5f;
    public float wanderSpeed = 1.0f;
    public float wanderPeriod = 3;
    bool moving = false;
    bool hollow = false;

    float transitTime;
	// Use this for initialization
	public void Start () {
        wanderTime = Random.RandomRange(0, wanderPeriod);
	}
	
	// Update is called once per frame
	public void Update () {


        if (inView > lit)
            highlightSprite.transform.localScale = new Vector3(.8f, .8f);
        else
        {
            highlightSprite.transform.localScale = new Vector3(1.3f, 1.3f);
            inView += Time.deltaTime;
        }

        if(hollow)
        {
            transitTime += Time.deltaTime;
            if (transitTime > takeTime)
            {

                GameObject.Destroy(this.gameObject);
            }
        }


	}

    public void inSight()
    {
        inView = 0;
    }

    public void drained()
    {
        hollow = true;

    }

    private void wander()
    {
        
    }

}
