using UnityEngine;
using System.Collections;

public class Initial : MonoBehaviour {

	float al;
	float timer;

	bool full;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat ("R", 0);
		PlayerPrefs.SetFloat ("G", 0);
		PlayerPrefs.SetFloat ("B", 0);
		PlayerPrefs.SetInt ("mute" , 0);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,al);
		if (!full) {
			al += 0.01f;
			if ((al > 0.999f) || (Input.anyKey)) {
				al = 1f;
				full = true;
			}
		} else {
			timer = Mathf.Lerp (timer,1f,0.05f);
			if (timer > 0.999f){
				al -= 0.01f;
				if ((al < 0.001f) || (Input.anyKey)) {
					al = 0;
					Application.LoadLevel("Main Menu");
				}
			}
		}
	}
}
