using UnityEngine;
using System.Collections;

public class MMItens : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver (){
		if (Input.GetMouseButtonDown (0)) {
			if (GetComponent<SpriteRenderer>().color.a > 0.999f){
				Application.LoadLevel ("cutacena");
			}
		}
	}
}
