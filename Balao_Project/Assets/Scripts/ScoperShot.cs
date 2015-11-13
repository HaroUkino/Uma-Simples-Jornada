using UnityEngine;
using System.Collections;

public class ScoperShot : MonoBehaviour {

	public bool pegasus;
	public bool come_back;


	private bool around;
	// Use this for initialization
	void Start () {
		pegasus = false;
		come_back = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.C)) && (around)) {

			if (PlayerPrefs.GetInt("Fdial") != 2){
				PlayerPrefs.SetInt("Fdial", 2);
			}

			pegasus = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().can_move = false;
			GameObject.Find("BlackScreen").GetComponent<Intro>().status = 0;
			GameObject.Find("BlackScreen2").GetComponent<Intro>().status = 0;
		}
		if ((come_back) && (GameObject.Find("BlackScreen2").GetComponent<SpriteRenderer>().color.a == 1f)) {
			GameObject.Find("Scope").GetComponent<Camera>().depth = -3;
			GameObject.Find("BlackScreen").GetComponent<Intro>().status = 1;
			come_back = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().can_move = true;
		}
	}
	void OnTriggerEnter2D (){
		around = true;
	}

	void OnTriggerExit2D(){
		around = false;
	}
}
