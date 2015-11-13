
// Criado Por Pedro Henrique (Haro Ukino) haroukino@hotmail.com
using UnityEngine;
using System.Collections;

public class Images : MonoBehaviour {

	public Sprite[] imgs;
	public float dmp;
	public GUISkin skin;

	private float timer;
	private int n;
	private int m;
	private float al;
	private float al2;
	private float al3;
	private bool can_fade;
	private bool[] fades = new bool[] {false,false};

	SpriteRenderer bs;

	// Use this for initialization
	void Start () {
		bs = GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>();
		this.gameObject.AddComponent<SpriteRenderer> ();
		n = -1;
		al2 = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("mute") > 0){
			AudioListener.pause = true;
		} else {
			AudioListener.pause = false;
		}

		al2 = Mathf.Lerp (al2,0,Time.deltaTime/5);

		if (n <= imgs.Length -1) {
			if (can_fade){
				fades[0] = true;
			} else if (!fades[1]){
				n++;
				fades[1] = true;
			}
			if (fades[0]){
				al = Mathf.Lerp(al,1f,Time.deltaTime * 2f);
				if (al > 0.999f){
					al = 1f;
					timer = 0;
					can_fade = false;
					fades[0] = false;
				}
			}
			if (fades[1]){
				al = Mathf.Lerp(al,0,Time.deltaTime * 2f);
				if (al < 0.001f){
					al = 0;
				}
				timer = Mathf.Lerp(timer,1f,dmp);
				if (timer > 0.999f){
					timer = 1f;
					can_fade = true;
					fades[1] = false;
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.A)){
			n++;
		}

		if ((n == imgs.Length) || (Input.GetKeyDown(KeyCode.Escape))){
			Application.LoadLevel ("Main Menu");
		}

		bs.color = new Color (1,1,1,al);
		if ((n != -1) && (n != imgs.Length)){
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = imgs [n];
		}
	}

	void OnGUI(){
		GUI.skin = skin;
		skin.label.normal.textColor = new Color (1,1,1,al2);
		skin.label.fontSize = Screen.width / 50;
		GUI.Label (new Rect (10,10,300,200),"Pressione 'Esc' Para Sair");
	}
}
