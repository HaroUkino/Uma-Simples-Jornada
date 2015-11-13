using UnityEngine;
using System.Collections;

public class NPCAnim : MonoBehaviour {
	NPCMove npc_mov;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		npc_mov = this.GetComponent<NPCMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if (npc_mov.move_x != 0) {
			anim.SetBool("Runin", true);
		} else {
			anim.SetBool("Runin", false);
		}
	}
}
