/// <summary>
/// Spanw Ballon Dialogue
/// </summary>
using UnityEngine;
using System.Collections;

public class Ballon_spawn : MonoBehaviour {
	public bool direct;
	public bool begone;
	//public float damp;

	// color
	float alpha = 1;
	float r = 1;
	float g = 1;
	float b = 1;

	//private float timer;
	private float direction;
	private float resize;
	private Transform self_parent;
	private float begin_time;

	// Use this for initialization
	void Start () {
		resize = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		resize = Mathf.Lerp(resize,1,0.05f);
		if (resize >= 0.999f){
			resize = 1;
		}
		if (!direct) {
			transform.localScale = new Vector2 (resize * -1, resize);
		} else {
			transform.localScale = new Vector2 (resize,resize);
		}

		if ((resize == 1) && (begone)){
			//timer = Mathf.Lerp (timer,1,damp);
			alpha -= 0.01f;
			this.GetComponent<SpriteRenderer> ().color = new Color(r,g,b,alpha);
			if (alpha <= 0) {
				Destroy(this.gameObject);
			}
		}
	}
}
