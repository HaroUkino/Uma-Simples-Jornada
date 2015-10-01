using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	public float x;
	public float y;

	float r;
	float g;
	float b;

	bool[] plus = new bool[] {false,false,false};
	bool[] minus = new bool[] {false,false,false};

	// Use this for initialization
	void Start () {
		r = 10;
		g = 10;
		b = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (plus[0]){
			if (r >= 10){
				r = 10f;
			} else {
				r += 1f;
			}
		}
		if (plus[1]){
			if (g >= 10){
				g = 10f;
			} else {
				g += 1f;
			}
		}
		if (plus[2]){
			if (b >= 10){
				b = 10f;
			} else {
				b += 1f;
			}
		}
		if (minus [0]) {
			if (r <= 0){
				r = 0;
			} else {
				r -= 1f;
			}
		}
		if (minus [1]) {
			if (g <= 0){
				g = 0;
			} else {
				g -= 1f;
			}
		}
		if (minus [2]) {
			if (b <= 0){
				b = 0;
			} else {
				b -= 1f;
			}
		}

		PlayerPrefs.SetFloat ("R", r/10);
		PlayerPrefs.SetFloat ("G", g/10);
		PlayerPrefs.SetFloat ("B", b/10);
		GameObject.Find("PlrSpr").GetComponent<SpriteRenderer> ().color = new Color (r/10,g/10,b/10);
	}

	void OnGUI(){

		plus[0] = GUI.Button (new Rect (x + 30f , y, 20, 20), "+");
		GUI.Label  (new Rect (x , y, 20, 20), "r");
		GUI.Label  (new Rect (x - 60f, y, 20, 20), r.ToString ());
		minus[0] = GUI.Button (new Rect (x - 30f, y, 20, 20), "-");

		plus[1] = GUI.Button (new Rect (x + 30f , y + 25f, 20, 20), "+");
		GUI.Label  (new Rect (x , y + 25f, 20, 30), "g");
		GUI.Label  (new Rect (x - 60f, y + 25f, 40, 40), g.ToString ());
		minus[1] = GUI.Button (new Rect (x - 30f, y + 25f, 20, 20), "-");

		plus[2] = GUI.Button (new Rect (x + 30f , y + 50f, 20, 20), "+");
		GUI.Label  (new Rect (x , y + 50f, 20, 20), "b");
		GUI.Label  (new Rect (x - 60f, y + 50f, 40, 40), b.ToString ());
		minus[2] = GUI.Button (new Rect (x - 30f, y + 50f, 20, 20), "-");
	}
}
