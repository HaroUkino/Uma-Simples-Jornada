using UnityEngine;
using System.Collections;

public class ParticleLayer : MonoBehaviour {

	ComunicationAndStatusPlayer cmc;

	// Use this for initialization
	void Start () {
		cmc = GameObject.FindGameObjectWithTag ("Player").GetComponent<ComunicationAndStatusPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<ParticleSystem> ().renderer.sortingLayerName = "Particles";
		if (cmc.stats_value == 2) {
			GetComponent<ParticleSystem>().startColor = new Color (0.4f,0.5f,0.7f);
		}
		if (cmc.stats_value == 3) {
			GetComponent<ParticleSystem>().startColor = new Color (0.4f,0.8f,0.4f);
		}
		if (cmc.stats_value == 4) {
			GetComponent<ParticleSystem>().startColor = new Color (0.95f,0.9f,0.4f);
		}
		if (cmc.stats_value == 5) {
			GetComponent<ParticleSystem>().startColor = new Color (0.9f,0.55f,0.25f);
		}
		if (cmc.stats_value == 6) {
			GetComponent<ParticleSystem>().startColor = new Color (0.95f,0.4f,0.45f);
		}
	}
}
