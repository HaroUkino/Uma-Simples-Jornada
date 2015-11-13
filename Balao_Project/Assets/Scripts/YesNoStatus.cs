using UnityEngine;
using System.Collections;

public class YesNoStatus : MonoBehaviour {

	public int status;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			if (status == 0) {
				if (this.gameObject.name == "sim") {
					Application.LoadLevel ("Main Menu");
				} else {
					GameObject.Find ("sim").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("sim").GetComponent<BoxCollider2D> ().enabled = false;
					GameObject.Find ("nao").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("sim").GetComponent<BoxCollider2D> ().enabled = false;
					GameObject.Find ("menu inicial").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("BlackScreen3").GetComponent<Intro> ().status = 1;
					GameObject[] psd_bnt = GameObject.FindGameObjectsWithTag("psd");
					foreach (GameObject btn in psd_bnt){
						btn.GetComponent<BoxCollider2D>().enabled = true;
					}
				}
			}
			if (status == 1){
				if (this.gameObject.name == "nao") {
					GameObject.Find("ColaPick").GetComponent<ColorPick>().changing = true;
					GameObject.Find ("sim").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("sim").GetComponent<BoxCollider2D> ().enabled = false;
					GameObject.Find ("nao").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("nao").GetComponent<BoxCollider2D> ().enabled = false;
					GameObject.Find ("eacor").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("BlackScreen").GetComponent<Intro> ().status = 1;
					GameObject[] psd_bnt = GameObject.FindGameObjectsWithTag("psd");
					foreach (GameObject btn in psd_bnt){
						btn.GetComponent<BoxCollider2D>().enabled = true;
					}
				} else {
					Application.LoadLevel("cutacena");
					PlayerPrefs.SetInt("Fdial",0);
				}
			}
			if (status == 2){
				if (this.gameObject.name == "sim") {
					Application.Quit();
				} else {
					GameObject.Find("ColaPick").GetComponent<ColorPick>().changing = true;
					GameObject.Find ("sim").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("sim").GetComponent<BoxCollider2D> ().enabled = false;
					GameObject.Find ("nao").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("nao").GetComponent<BoxCollider2D> ().enabled = false;
					GameObject.Find ("vaisair").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
					GameObject.Find ("BlackScreen").GetComponent<Intro> ().status = 1;
					GameObject[] psd_bnt = GameObject.FindGameObjectsWithTag("psd");
					foreach (GameObject btn in psd_bnt){
						btn.GetComponent<BoxCollider2D>().enabled = true;
					}
				}
			}
		}
	}
}
