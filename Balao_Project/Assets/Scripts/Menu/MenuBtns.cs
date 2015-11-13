using UnityEngine;
using System.Collections;

public class MenuBtns : MonoBehaviour {

	public string btn_name;
	public int status;
	public float x,y;
	public GUISkin skin;
	public Sprite[] listen;

	private Rect location;
	private float w;
	private bool mouse;
	private bool mute;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt("mute",1);
		PlayerPrefs.SetFloat("R" , 0);
		PlayerPrefs.SetFloat("G" , 0);
		PlayerPrefs.SetFloat("B" , 0);
		GameObject.Find ("nao").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("sim").GetComponent<BoxCollider2D> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt("mute") > 0){
			AudioListener.pause = true;
			mute = true;
		} else {
			AudioListener.pause = false;
			mute = false;
		}

		location = new Rect (Screen.width/10 * x,Screen.height/10 * y,w,Screen.width/22);
		if (mouse) {
			w = Mathf.Lerp (w, Screen.width/3,Time.deltaTime * 2f);
		} else {
			w = Mathf.Lerp (w, 0,Time.deltaTime * 2f);

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
		if (this.gameObject.GetComponent<SpriteRenderer> ().color.a > 0.7f) {
			mouse = true;
			if (Input.GetMouseButtonDown(0)){
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
				if (status == 0){
					if ((PlayerPrefs.GetFloat("R") == 0) && (PlayerPrefs.GetFloat("G") == 0) && (PlayerPrefs.GetFloat("B") == 0)){
						GameObject.Find("ColaPick").GetComponent<ColorPick>().changing = false;
						GameObject.Find ("sim").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
						GameObject.Find ("sim").GetComponent<BoxCollider2D> ().enabled = true;
						GameObject.Find ("sim").GetComponent<YesNoStatus>().status = 1;
						GameObject.Find ("nao").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
						GameObject.Find ("nao").GetComponent<BoxCollider2D> ().enabled = true;
						GameObject.Find ("nao").GetComponent<YesNoStatus>().status = 1;
						GameObject.Find ("eacor").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
						GameObject.Find ("BlackScreen").GetComponent<Intro> ().status = 2;
						GameObject[] psd_bnt = GameObject.FindGameObjectsWithTag("psd");
						foreach (GameObject btn in psd_bnt){
							btn.GetComponent<BoxCollider2D>().enabled = false;
						}
					} else {
						Application.LoadLevel("cutacena");
						PlayerPrefs.SetInt("Fdial",0);
					}
				}
				if (status == 1){
					Application.LoadLevel("Credits");
				}
				if (status == 3){
					GameObject.Find("ColaPick").GetComponent<ColorPick>().changing = false;
					GameObject.Find ("sim").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
					GameObject.Find ("sim").GetComponent<BoxCollider2D> ().enabled = true;
					GameObject.Find ("sim").GetComponent<YesNoStatus>().status = 2;
					GameObject.Find ("nao").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
					GameObject.Find ("nao").GetComponent<BoxCollider2D> ().enabled = true;
					GameObject.Find ("nao").GetComponent<YesNoStatus>().status = 2;
					GameObject.Find ("vaisair").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
					GameObject.Find ("BlackScreen").GetComponent<Intro> ().status = 2;
					GameObject[] psd_bnt = GameObject.FindGameObjectsWithTag("psd");
					foreach (GameObject btn in psd_bnt){
						btn.GetComponent<BoxCollider2D>().enabled = false;
					}
				}
			}
		}
	}

	void OnMouseExit (){
		mouse = false;
	}

	void OnGUI(){
		if (status != 2) {
			GUI.skin = skin;
			skin.label.normal.textColor = Color.black;
			GUI.skin.label.fontSize = Screen.height/20;
			GUI.Label (location, btn_name);
		}
	}
}
