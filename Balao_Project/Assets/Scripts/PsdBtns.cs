using UnityEngine;
using System.Collections;

public class PsdBtns : MonoBehaviour {

	public bool GP;
	public bool chill;
	public int status;
	public Sprite[] listen;

	private bool mute;

	// Use this for initialization
	void Awake () {
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GP) {
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,1f);
			if (Input.GetMouseButtonDown (1)) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<KeepinItCool>().pause = false;
				GameObject.Find("BlackScreen").GetComponent<Intro>().status = 1;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().can_move = true;
			}
		} else {
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0);
		}

		if (status == 2){
			// sprite
			if (mute){
				this.gameObject.GetComponent<SpriteRenderer>().sprite = listen[1];
			} else {
				this.gameObject.GetComponent<SpriteRenderer>().sprite = listen[0];
			}
		}
	}

	void OnMouseOver (){
		if (chill) {
			return;
		}
		if (Input.GetMouseButtonDown (0)) {
			if (status == 0){
				GameObject.FindGameObjectWithTag("Player").GetComponent<KeepinItCool>().pause = false;
				GameObject.Find("BlackScreen").GetComponent<Intro>().status = 1;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().can_move = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = true;
			}
			if (status == 1){
				GameObject[] psd_bnt = GameObject.FindGameObjectsWithTag("psd");
				foreach (GameObject btn in psd_bnt){
					btn.GetComponent<BoxCollider2D>().enabled = false;
				}

				GameObject.Find("sim").GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,1f);
				GameObject.Find("sim").GetComponent<BoxCollider2D>().enabled = true;
				GameObject.Find("nao").GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,1f);
				GameObject.Find("nao").GetComponent<BoxCollider2D>().enabled = true;
				GameObject.Find("menu inicial").GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,1f);
				GameObject.Find("BlackScreen3").GetComponent<Intro>().status = 2;
			}
			if (status == 2){
				if (mute){
					PlayerPrefs.SetInt("mute",0);
					mute = false;
					AudioListener.pause = false;
				} else {
					PlayerPrefs.SetInt("mute",1);
					mute = true;
					AudioListener.pause = true;
				}
			}
		}
	}
}
