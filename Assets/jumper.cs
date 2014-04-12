using UnityEngine;
using System.Collections;

public class jumper : MonoBehaviour {

    public float radius = .5f;
    public Transform arrow;

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

        arrow.GetComponent<BoxCollider2D>().transform.rotation = Quaternion.AngleAxis(angle * (180 / Mathf.PI) - 90, Vector3.forward);

	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, arrow.renderer.bounds.size.y * radius);
    }
}
