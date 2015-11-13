//criado por Pedro Henrique (HaroUkino) haroukino@hotmail.com

using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	//bool gup;
	//bool led;

	Transform plr_pos;
	//PlayerMove plr_mov;
	// Use this for initialization
	void Start () {
		//plr_mov = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		plr_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		if (plr_pos.position.y > this.gameObject.transform.position.y + this.gameObject.transform.localScale.y * 1f) {
			this.gameObject.collider2D.enabled = true;
		} else {
			this.gameObject.collider2D.enabled = false;
		}
	}
}
