using UnityEngine;
using System.Collections;

public class jumper : MonoBehaviour {

    public float radius = .5f;
    public Transform arrow;
    public float jumpSpeed = 5;
    public float drag = .8f;
    bool setup =  true;

    Vector3 jumpMomentum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        float distance = Mathf.Sqrt(Mathf.Pow(horiz , 2) + Mathf.Pow(vert,2));
        float angle = Mathf.Atan2(vert, horiz);

        arrow.transform.localScale = new Vector3(distance * radius, distance * radius);
        arrow.transform.rotation = Quaternion.AngleAxis(angle * (180/Mathf.PI) - 90, Vector3.forward);
        arrow.transform.position = this.gameObject.transform.position;

        Debug.Log(distance);
        if(distance >= .95f  && setup)
        {
            jumpMomentum = new Vector3(horiz, vert, 0);
            jumpMomentum.Normalize();
            jumpMomentum *= jumpSpeed;
            setup = false;
        }

        if(!setup)
        {
            this.gameObject.transform.position += jumpMomentum * Time.deltaTime;
            jumpMomentum = jumpMomentum * drag;
            Debug.Log(jumpMomentum);

            if(jumpMomentum.magnitude < .2)
            {
                jumpMomentum *= 0;
            }

            if(new Vector3(horiz,vert,0).magnitude < .6)
            {
                setup = true;
            }

        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, arrow.renderer.bounds.size.y * radius);
    }

    public void explode()
    {
        GameObject.Destroy(this.gameObject);
    }
}
