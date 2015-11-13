using UnityEngine;
using System.Collections;

public class Meteoro : MonoBehaviour {

	public Transform Limit;

	Vector3 ini_pos;

	// Use this for initialization
	void Start () {
		ini_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if ((GameObject.Find ("Scoper").GetComponent<ScoperShot> ().pegasus) && (GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>().color.a == 1f)) {
			GameObject.Find("Scope").GetComponent<Camera>().depth = 3;
			GameObject.Find("BlackScreen2").GetComponent<Intro>().status = 1;
			transform.position = new Vector2 (transform.position.x + 0.1f,transform.position.y - 0.05f);
		}
		if (transform.position.y < Limit.position.y){
			GameObject.Find ("Scoper").GetComponent<ScoperShot> ().pegasus = false;
			GameObject.Find ("Scoper").GetComponent<ScoperShot> ().come_back = true;
			GameObject.Find("BlackScreen2").GetComponent<Intro>().status = 0;
			transform.position = ini_pos;
		}
	}
}
