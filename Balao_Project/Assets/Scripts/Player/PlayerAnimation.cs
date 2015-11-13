// criado por Pedro Henrique (HaroUkino) haroukino@hotmail.com
// Esse e o script de animaçao,meio obvio nao?

using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	public Sprite spr;

	private Animator animator;
	private float mov;
	float t;

	PlayerMove plr_mov;
	GameObject sml,sml2;

	// Use this for initialization
	void Start () {

		// Aqui e Onde Pegamos o Animator Do Jogador,Assim Podemos Acessar Suas Variaveis
		animator = this.GetComponent<Animator> ();

		// Importa as variaveis do script 'PlayerMove'
		plr_mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
		sml = GameObject.Find("Smile");
		sml2 = GameObject.Find("Smile2");
	}
	
	// Update is called once per frame
	void Update () {
		// Animaçao De Pulo
		if ((animator.GetBool("happy")) || (animator.GetBool("sad"))){
			t = Mathf.Lerp (t,1,Time.deltaTime *2);
			plr_mov.can_move = false;
			if (t > 0.999f){
				animator.SetBool("happy",false);
				animator.SetBool("sad",false);
				if (!plr_mov.cinematic){
					plr_mov.can_move = true;	
				}
			}
		} else {
			t = 0;
		}
		// Se a Velocidade Vertical e 0, Entao Nao Ha Animaçao De Pulo Ou De Queda.
		//if ((!plr_mov.flying) && (plr_mov.move_y == 0)) {
		if (plr_mov.OnGround){
			animator.SetBool ("Fall", false);
			animator.SetBool ("Jump", false);
		} else {
			// Se a Velocidade Vertical For Menor Que 0,Entao o Jogador Esta Caindo,Entao Queda = true Pulo = False
			if ((!plr_mov.OnGround) && (!plr_mov.flying) && (rigidbody2D.velocity.y < 0)){
				animator.SetBool ("Fall", true);
				animator.SetBool ("Jump", false);
			}
			// Se a Velocidade Vertical For Maior Que 0,Entao o Jogador Esta Pulando,Entao Queda = False Pulo = True
			if ((plr_mov.flying) || (rigidbody2D.velocity.y > 0)){
				animator.SetBool ("Jump", true);
				animator.SetBool ("Fall", false);
			}
		}

		// Animaçao De Andar e Direçao Do Personagem

		// Essa Variavel Nos Diz Se o Jogador Esta Andando e Qual Direçao Ele Anda Dependendo Do Botao Que Ele Aperta

		if (plr_mov.flying) {
			mov = Input.GetAxisRaw ("Horizontal");
		} else {
			mov = plr_mov.move_x;
		}
		// Se Nao Estiver Retornando 0, Animaçao De Andar,Caso Contrario,Esta Parado

		if (mov != 0) {
			// Aqui e Onde Sabemos Para Que Lado Esta Olhando: -1 =  Esquerda, 1 = Direita
			transform.localScale = new Vector2 (mov, transform.localScale.y);
			animator.SetInteger ("Bases", 0);
		} else {
			animator.SetInteger ("Bases", 1);
		}

		if (animator.GetBool ("happy")) {
			if (sml2 == null) {
				return;
			} else {
				sml2.GetComponent<SpriteRenderer> ().enabled = true;
			}
		} else {
			sml2.GetComponent<SpriteRenderer> ().enabled = false;
		}

		if (animator.GetBool ("Jump")) {
			if (sml == null) {
				return;
			} else {
				if (GameObject.FindGameObjectWithTag ("Player").GetComponent<SpriteRenderer> ().sprite == spr) {
					sml.GetComponent<SpriteRenderer> ().enabled = true;
				}
			}
		} else {
			if (sml != null) {
				sml.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}
}