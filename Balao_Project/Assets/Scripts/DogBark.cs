using UnityEngine;
using System.Collections;

public class DogBark : MonoBehaviour {
	
	public Sprite b_spr;
	
	bool pld;
	
	void Update(){
		if (GetComponent<SpriteRenderer>().sprite == b_spr) {
			if ((!audio.isPlaying) && (!pld)){
				audio.Play();
				pld = true;
			} else {
				pld = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			this.gameObject.GetComponent<Animator> ().SetBool ("bark", true);
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Player") {
			if (other.GetComponent<PlayerMove>().dialog){
				this.gameObject.GetComponent<Animator> ().SetBool ("bark", false);
			} else {
				this.gameObject.GetComponent<Animator> ().SetBool ("bark", true);
			}
		}
	}

	void OnTriggerExit2D (){
		this.gameObject.GetComponent<Animator> ().SetBool ("bark", false);
	}
}
