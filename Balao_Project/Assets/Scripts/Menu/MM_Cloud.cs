using UnityEngine;
using System.Collections;

public class MM_Cloud : MonoBehaviour {

	float velCloud = 0.6f;
	public GameObject limite;
	public GameObject inicio;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(velCloud * Time.deltaTime,0,0);
		if (transform.position.x > limite.transform.position.x) {
			transform.position = new Vector2(inicio.transform.position.x,transform.position.y);
		}
	}
}
