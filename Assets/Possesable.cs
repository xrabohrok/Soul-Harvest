using UnityEngine;
using System.Collections;

public class Possesable : MonoBehaviour {

    public Transform highlightSprite;

    float inView;
    public float lit = .2f;
    public float takeTime = .5f;
    bool hollow = false;

    float transitTime;
	// Use this for initialization
	public void Start () {
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

}
