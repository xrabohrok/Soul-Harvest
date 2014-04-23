using UnityEngine;
using System.Collections;

public class spiritEffect : MonoBehaviour {

    public float speed = .3f;

    Vector3 start;
    Vector3 end;

    float pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        pos += Time.deltaTime * speed;

        this.gameObject.transform.position = Vector3.Lerp(start, end, pos);

        this.gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(end.y - start.y, end.x - start.y) * (180/Mathf.PI), Vector3.forward);

        if (pos > 1)
            GameObject.Destroy(this.gameObject);
	}

    public void go(Transform a, Transform b)
    {
        start = a.position;
        end = b.position;
    }
}
