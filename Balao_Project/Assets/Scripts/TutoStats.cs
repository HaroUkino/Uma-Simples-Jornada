using UnityEngine;
using System.Collections;

public class TutoStats : MonoBehaviour {

	public int status;
	public int req;
	public bool above;

	private Vector3 pos;
	private float a = 1f;

	Camera cam;


	void Awake (){
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
		PlayerPrefs.SetInt("Fdial", 0);
	}

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (status == 0) {
			pos = cam.WorldToViewportPoint(transform.position);
			if ((PlayerPrefs.GetInt("tuto1") == 1) && (a < 0.001f)){
				return;
			}
			if (pos.x < 0.1f){
				a = Mathf.Lerp(a,0,Time.deltaTime * 2);
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, a);
				PlayerPrefs.SetInt("tuto1",1);
			} else {
				a = Mathf.Lerp(a,1f,Time.deltaTime * 2);
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, a);
			}
		}

		if (status == 1) {
			if (req < GameObject.FindGameObjectWithTag("Player").GetComponent<ComunicationAndStatusPlayer>().stats_value + 1){
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
			} else {
				if (transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y){
					above = true;
				}

				if (above){
					a = Mathf.Lerp(a,1f,Time.deltaTime * 2);
					pos = cam.WorldToViewportPoint(transform.position);
					if ((pos.x < 0) || (pos.x > 1f)){
						above = false;
					}
				} else {
					a = Mathf.Lerp(a,0,Time.deltaTime * 2);
				}
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, a);
			}
		}

		if (status == 2) {
			if (PlayerPrefs.GetInt("Fdial") >= 1){
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			}
		}

		if (status == 3) {
			if (PlayerPrefs.GetInt("Fdial") == 2){
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			}
		}
	}
}
