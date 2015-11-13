using UnityEngine;
using System.Collections;

public class NPCMove : MonoBehaviour {

	public bool[] side = new bool[] {false,false};
	public float move_x;

	float key_left;
	float key_right;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,1f),Random.Range(0,1f),Random.Range(0,1f));
	}
	
	// Update is called once per frame
	void Update () {
		leAxis ();
	}

	void leAxis(){
		if (side[0]){
			key_left = -1f;
		} else {
			key_left = 0;
		}
		if (side[1]){
			key_right = 1f;
		} else {
			key_right = 0;
		}
		
		move_x = key_left + key_right;
		transform.position = new Vector2 (transform.position.x + move_x/10f, transform.position.y);
	}
}
