/// <summary>
/// Script Criado Por Pedro Henrique (Haro Ukino) xiunnob@gmail.com
/// </summary>

using UnityEngine;
using System.Collections;

public class lePosicion : MonoBehaviour {
	public bool[] order = new bool[] {false,false,false,false};
	public int n;
	public Transform ini_pos;
	CutSceneControl cntrl;
	GameControl gm_cntrl;
	// Use this for initialization
	void Start () {
		cntrl = GameObject.Find ("Main Camera").GetComponent<CutSceneControl> ();
		gm_cntrl = GameObject.Find ("Main Camera").GetComponent<GameControl> ();
		if (ini_pos != null) {
			transform.position = ini_pos.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if ((other.gameObject.name == "Player") || (other.gameObject.name == "NPCF")) {
			if (order [n] == true){ 
				if (cntrl != null){
					cntrl.CheckIn[n] = true;
				} else {
					gm_cntrl.CheckIn[n] = true;
				}
			}
			Destroy (this.gameObject);
		}
	}
}
