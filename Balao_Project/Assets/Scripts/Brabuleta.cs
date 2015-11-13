// Criado Por Pedro Henrique (Haro Ukino) haroukino@hotmail.com

using UnityEngine;
using System.Collections;

public class Brabuleta : MonoBehaviour {

	public float spd;

	// Update is called once per frame
	void Update () {


		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<KeepinItCool> ().pause) {
			this.gameObject.GetComponent<Animator> ().enabled = false;
			return;
		} else {
			this.gameObject.GetComponent<Animator> ().enabled = true;
		}
		transform.position = new Vector2 (transform.position.x - (spd * transform.localScale.x),Mathf.Sin(transform.position.x/2));

		if (transform.position.x > GameObject.Find("Limit2").transform.position.x + 5f) {
			Destroy(this.gameObject);
		}

		if (transform.position.x < GameObject.Find("Limit1").transform.position.x - 5f) {
			Destroy(this.gameObject);
		}
	}
}
