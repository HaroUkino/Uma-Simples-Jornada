using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public int pos;
	public float h;
	public float w;

	ComunicationAndStatusPlayer plr_cm;
	//CamControl cam;
	KeepinItCool kptc;

	// Use this for initialization
	void Start () {
		plr_cm = GameObject.FindGameObjectWithTag ("Player").GetComponent<ComunicationAndStatusPlayer>();
		kptc = GameObject.FindGameObjectWithTag ("Player").GetComponent<KeepinItCool>();
		//cam = GameObject.Find("Main Camera").GetComponent<CamControl>();
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rot = new Quaternion (0, 0, 1f, 1f);
		if (pos == 0) {
			transform.rotation = rot;
			transform.position = new Vector3 (transform.parent.position.x + 0.5f,transform.parent.position.y + Camera.main.orthographicSize - 1,10);
		}
		if (pos == 1) {
			transform.rotation = new Quaternion (0,0,0,0);
			transform.position = new Vector3 (transform.parent.position.x + Camera.main.orthographicSize * 1.5f,transform.parent.position.y,10);
		}
		if (pos == 2) {
			transform.rotation = new Quaternion (0,0,0,0);
			transform.position = new Vector3 (transform.parent.position.x + (-1 * ( Camera.main.orthographicSize * 1.5f)),transform.parent.position.y,10);
		}
		if (pos == 3) {
			transform.rotation = rot;
			transform.position = new Vector3 (transform.parent.position.x + 0.5f,transform.parent.position.y +(-1 * ( Camera.main.orthographicSize - 1)),10);
		}
		if (pos == 4) {
			transform.rotation = new Quaternion (0,0,0,0);
			transform.position = new Vector3 (transform.parent.position.x + Camera.main.orthographicSize * w,transform.parent.position.y +(-1 * ( Camera.main.orthographicSize - h)),10);
		}
		//(cam.Dial) || 
		if ((kptc.pause)) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find("hudbg").GetComponent<SpriteRenderer>().enabled = false;
		} else {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find("hudbg").GetComponent<SpriteRenderer>().enabled = true;
			Animator anim = this.gameObject.GetComponent<Animator> ();
			anim.SetInteger ("value", plr_cm.stats_value - 1);
		}
	}
}
