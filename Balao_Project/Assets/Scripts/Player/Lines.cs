using UnityEngine;
using System.Collections;

public class Lines : MonoBehaviour {

	public Transform bln;

	PlayerMove plr_mov;

	// Use this for initialization
	void Start () {
		plr_mov = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!plr_mov.OnGround) {
			GetComponent<LineRenderer> ().SetPosition (0, new Vector3 (transform.position.x + (0.5f * transform.localScale.x), transform.position.y + 1f));
		} else {
			GetComponent<LineRenderer> ().SetPosition (0, new Vector3 (transform.position.x, transform.position.y + 1f));
		}
		GetComponent<LineRenderer> ().SetPosition (1, new Vector3 (bln.position.x,bln.position.y));

	}
}
