using UnityEngine;
using System.Collections;

public class Possesable : MonoBehaviour {

    public Transform highlightSprite;

    float inView;
    public float light = .2f;

	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {


        if (inView > light)
            highlightSprite.transform.localScale = new Vector3(.8f, .8f);
        else
        {
            highlightSprite.transform.localScale = new Vector3(1.3f, 1.3f);
            inView += Time.deltaTime;
        }


	}

    public void inSight()
    {
        inView = 0;
    }

}
