using UnityEngine;
using System.Collections;

public class BGAudio : MonoBehaviour {

	public int status;
	float v;

	ComunicationAndStatusPlayer cmc_p;

	// Use this for initialization
	void Start () {
		cmc_p = GameObject.FindGameObjectWithTag ("Player").GetComponent<ComunicationAndStatusPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cmc_p.stats_value >= status){
			v = Mathf.Lerp (v,0.25f,0.01f);
			audio.volume = v;
		}
	}
}
