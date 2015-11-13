
// Criado Por Pedro Henrique(Haro Ukino) haroukino@hotmail.com 

using UnityEngine;
using System.Collections;

public class ColorBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver (){
		if ( Input.GetMouseButtonDown(0)){
			GameObject.FindGameObjectWithTag ("Player").GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<SpriteRenderer>().color;
			PlayerPrefs.SetFloat ("R", this.gameObject.GetComponent<SpriteRenderer>().color.r);
			PlayerPrefs.SetFloat ("G", this.gameObject.GetComponent<SpriteRenderer>().color.g);
			PlayerPrefs.SetFloat ("B", this.gameObject.GetComponent<SpriteRenderer>().color.b);
		}
	}
}
