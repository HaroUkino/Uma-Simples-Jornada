// Criado Por Pedro Henrique (Haro Ukino) haroukino@hotmail.com

using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public int status;

	float al;

	// Use this for initialization
	void Start () {
		if (status > 0) {
			al = 1f;
		} else {
			al = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (status == 1) {
			al = Mathf.Lerp (al,0,Time.deltaTime * 1.5f);
			if (al < 0.001f){
				al = 0;
			}
		} 
		if (status == 0){
			al = Mathf.Lerp (al,1f,Time.deltaTime * 1.5f);
			if (al > 0.999f){
				al = 1f;
			}
		}

		if (status == 2) {
			al = Mathf.Lerp (al,0.5f,Time.deltaTime * 1.5f);
			if (al < 0.501f){
				al = 0.5f;
			}
		}
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,al);
	}
}
