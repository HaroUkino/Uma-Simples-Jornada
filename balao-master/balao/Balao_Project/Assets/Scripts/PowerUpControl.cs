using UnityEngine;
using System.Collections;

public class PowerUpControl : MonoBehaviour {

	ComunicationAndStatusPlayer cmc_plr;
	PlayerMove plr_mov;
	public float req_value;
	bool isHere;

	// Use this for initialization
	void Start () {
		cmc_plr = GameObject.FindGameObjectWithTag("Player").GetComponent<ComunicationAndStatusPlayer>();
		plr_mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((cmc_plr.stats_value >= req_value) && (isHere)) {
			if (req_value == 2){
				transform.position = new Vector3 (transform.position.x, transform.position.y, 1f);
			}
			if (req_value == 3){
				transform.position = new Vector3 (transform.position.x, transform.position.y, 1f);
				plr_mov.onGreen = true;
			}
		} else {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 2f);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			isHere = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			isHere = false;
			plr_mov.onGreen = false;
		}
	}
}
