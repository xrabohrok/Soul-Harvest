using UnityEngine;
using System.Collections;

public class jumper : MonoBehaviour {

    public float radius = .5f;
    public Transform arrow;
    public float jumpSpeed = 5;
    public float drag = .8f;
    public float stretchSpeed = .5f;
    bool setup =  true;

    private float stretch;

    private static bool initialized = false;
    private static float radiusCommon;
    private static float jumpSpeedCommon;
    private static float stretchSpeedCommon;

    Vector3 jumpMomentum;

	// Use this for initialization
	void Start () {
        if (initialized)
        {
            radius = radiusCommon;
            jumpSpeed = jumpSpeedCommon;
            stretchSpeed = stretchSpeedCommon;
        }
        else
        {
            radiusCommon = radius;
            jumpSpeedCommon = jumpSpeed;
            stretchSpeedCommon = stretchSpeed;

            initialized = true;
        }
        stretch = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        float maxDistance = Mathf.Sqrt(Mathf.Pow(horiz , 2) + Mathf.Pow(vert,2));
        float angle = Mathf.Atan2(vert, horiz);

        if (stretch < maxDistance)
            stretch += stretchSpeed * Time.deltaTime;
        else
            stretch -= stretchSpeed * 2 * Time.deltaTime;

        arrow.transform.localScale = new Vector3(stretch * radius, stretch * radius);
        arrow.transform.rotation = Quaternion.AngleAxis(angle * (180/Mathf.PI) - 90, Vector3.forward);
        arrow.transform.position = this.gameObject.transform.position;

        Debug.Log(maxDistance);
        if (maxDistance >= .95f && setup)
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
