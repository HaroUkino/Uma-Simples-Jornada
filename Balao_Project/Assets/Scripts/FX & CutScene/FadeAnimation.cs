using UnityEngine;
using System.Collections;

public class FadeAnimation : MonoBehaviour {
	
	float alpha = 1;
	float r = 1;
	float g = 1;
	float b = 1;
	ComunicationAndStatusNPC npc_acpt;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (rigidbody2D != null){
			transform.localScale = new Vector2 (1 * transform.parent.localScale.x, 1);
		}
		*/
		alpha -= 0.01f;
		this.GetComponent<SpriteRenderer> ().color = new Color(r,g,b,alpha);
		if (alpha <= 0) {
			npc_acpt = GetComponentInParent<ComunicationAndStatusNPC>();
			if (npc_acpt != null){
				npc_acpt.acptin = false;
			}
			Destroy(this.gameObject);
		}
	}
	void FixedUpdate (){
		if (rigidbody2D != null){
			rigidbody2D.AddForce (new Vector2 (0, 10f));
		}
	}
}
