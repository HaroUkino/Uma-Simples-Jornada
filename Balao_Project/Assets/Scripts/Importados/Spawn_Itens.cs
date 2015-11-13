using UnityEngine;
using System.Collections;

public class Spawn_Itens : MonoBehaviour {
	// Variavel publica do tipo lista itens
	public GameObject[] itens;
	// Variavel publica do tipo ponto flutuante de nome limite
	public float limite;
	// Variavel publica do tipo ponto flutuante
	public float rate;

	// Variavel Privada do tipo buleana sendo lançou = a falso
	private bool lançou = false;
	// Variavel Privada do tipo ponto flutuante de nome tempo_lançamento
	private float tempo_lançamento;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Player").GetComponent<KeepinItCool>().pause){
			return;
		}

		//Se lançou
		if (!lançou) {
			//Instancia item de cena.
			float local_y_nascimento = Random.Range (-limite, limite);
			int indice_item_aleatorio = Random.Range (0, itens.Length);
			Instantiate (itens [indice_item_aleatorio], new Vector2 (transform.position.x, local_y_nascimento), Quaternion.identity);
			//FIM:Instancia item de cena.
			lançou = true;
			tempo_lançamento = Time.time;
		}

		if ((Time.time - tempo_lançamento) > rate) {
			lançou =false;
		}
		if (rate <= 0.5f) {
			rate = 0.5f;
		}
		//FIM: lançamento de Item.
	}
}
