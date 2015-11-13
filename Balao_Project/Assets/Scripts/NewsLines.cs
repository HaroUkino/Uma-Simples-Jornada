using UnityEngine;
using System.Collections;

public class NewsLines : MonoBehaviour {
	
	public Transform target;
	public float x_r;
	public bool cenario;
	LineRenderer l_r;

	// Use this for initialization
	void Start () {
		if (cenario) {
			GetComponent<SpriteRenderer>().color = new Color (Random.Range (0.5f,1f),Random.Range (0.5f,1f),Random.Range (0.5f,1f));
			GetComponent<SpringJoint2D>().distance = Random.Range(0.5f,2f);

		}
		l_r = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce (new Vector2 (Random.Range(-x_r,x_r),10f));
		l_r.SetPosition (0,transform.position);
		l_r.SetPosition (1,target.position);
	}
}
