using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	Transform plr_pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		plr_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		if (plr_pos.position.y > this.gameObject.transform.position.y + this.gameObject.transform.localScale.y * 2f) {
			this.gameObject.collider2D.enabled = true;
		} else {
			this.gameObject.collider2D.enabled = false;
		}
	}
}
