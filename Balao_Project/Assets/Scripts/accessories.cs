using UnityEngine;
using System.Collections;

public class accessories : MonoBehaviour {
	
	public GameObject parent_g;
	public bool change;
	public Sprite[] accs;

	Vector3 ini_pos;
	Sprite ini_sprite;
	float ini_pos_x;
	int lolen;

	// Use this for initialization
	void Awake () {
		ini_sprite = parent_g.GetComponent<SpriteRenderer> ().sprite;
		ini_pos = transform.position;
		ini_pos_x = parent_g.transform.position.x - ini_pos.x;
		lolen = accs.Length;
	}

	void Start (){
		if (change) {
			GetComponent<SpriteRenderer> ().sprite = accs [Random.Range (0, lolen)];
		}
	}

	// Update is called once per frame
	void Update () {


		if (parent_g.GetComponent<SpriteRenderer> ().sprite != ini_sprite) {
			transform.position = new Vector3 (transform.position.x, ini_pos.y - 0.02f);
		} else {
			transform.position = new Vector3 (transform.position.x,ini_pos.y);
		}
	}
}
