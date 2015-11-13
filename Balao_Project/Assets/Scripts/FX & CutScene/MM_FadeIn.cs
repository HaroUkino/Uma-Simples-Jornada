using UnityEngine;
using System.Collections;

public class MM_FadeIn : MonoBehaviour {
	public bool not_plr;
	public Transform f_pos;

	float Fade;
	Transform plr_pos;

	// Use this for initialization
	void Start () {
		if (not_plr) {
			GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		plr_pos = GameObject.Find("Plr").GetComponent<Transform>();
		if (this.gameObject.name != "Plr") {
			if ((not_plr) && !(plr_pos.position.y < f_pos.position.y)) {
				Fade += 0.05f;
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, Fade);
				if (Fade > 0.999f){
					GameObject.Find("ColaPick").GetComponent<ColorPick>().changing = true;
					this.enabled = false;
				}
			}
		} else {
			if (plr_pos.position.y < f_pos.position.y){
				plr_pos.position = new Vector2 (plr_pos.position.x,Mathf.Lerp (plr_pos.position.y,f_pos.position.y +1f,0.03f));
			}
		}
	}
}
