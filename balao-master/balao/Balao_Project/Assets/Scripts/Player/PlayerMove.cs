// Criado Por Pedro Henrique (Haro Ukino) haroukino@hotmail.com
// Esse e o script de movimentaçao do personagem (meio obvio nao acha?)

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Publics

	public float mov_speed;
	public float jmp_speed;
	public float max_speed;
	public float max_height;
	public bool onGreen;
	public bool OnGround;
	public bool can_move;
	public bool cinematic;
	public bool from_axis;
	public bool flying;
	public bool dialog;
	public bool[] side = new bool[] {false,false};
	public bool speed;
	public string Importante;
	public float move_x;
	public float move_y;
	public float hsp;
	public Transform drag;



	// Privates
	private bool MaxDistance;
	private bool canFly;
	private bool fall;
	private bool stp_r, stp_l;
	private bool fly_audio;
	private float max_fall = -10.0f;
	private float key_left;
	private float key_right;
	private float stp;
	private float resize;
	private float maxH;
	private float[] timer = new float[] {0,0,0};
	private int lerp_fix;


	//PlayerAnimation plr_anim;
	balao bln;

	// Use this for initialization
	void Start () {
		maxH = max_height;
		if (!cinematic) {
			can_move = true;
		} else {
			can_move = false;
		}
		hsp = 0;
		move_x = 0;
		move_y = 0;
		//plr_anim = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
		bln = GameObject.FindGameObjectWithTag("plr_bln").GetComponent<balao>();
		resize = 0.8f;
	}


	// Update is called once per frame
	void Update () {

		// Pegando as Cores
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (PlayerPrefs.GetFloat("R"),PlayerPrefs.GetFloat("G"),PlayerPrefs.GetFloat("B"));

		// Checando Colisões -- Inicio

		// Verticais
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, 0.15f, -5, 0.9f, 1.1f);
		RaycastHit2D hitfix_1 = Physics2D.Raycast (new Vector3 (transform.position.x - 0.14f , transform.position.y), -Vector2.up, 0.15f, -5, 0.9f, 1.1f);
		RaycastHit2D hitfix_2 = Physics2D.Raycast (new Vector3 (transform.position.x + 0.15f, transform.position.y), -Vector2.up, 0.15f, -5, 0.9f, 1.1f);

		// Horizontais
		// Direita
		RaycastHit2D hitR1 = Physics2D.Raycast (new Vector3 (transform.position.x + 0.2f, transform.position.y+ 0.1f),Vector2.right,0.5f, -5, 0.9f,1.1f);
		RaycastHit2D hitR2 = Physics2D.Raycast (new Vector3 (transform.position.x + 0.2f, transform.position.y + 1f),Vector2.right,0.5f, -5, 0.9f,1.1f);
		RaycastHit2D hitR3 = Physics2D.Raycast (new Vector3 (transform.position.x + 0.2f, transform.position.y + 1.75f),Vector2.right,0.5f, -5, 0.9f,1.1f);

		Debug.DrawRay (new Vector3 (transform.position.x + 0.175f, transform.position.y + 0.1f),Vector2.right,Color.blue);
		Debug.DrawRay (new Vector3 (transform.position.x + 0.175f, transform.position.y + 1f),Vector2.right,Color.blue);
		Debug.DrawRay (new Vector3 (transform.position.x + 0.175f, transform.position.y + 1.75f),Vector2.right,Color.blue);

		if ((hitR1 != null && hitR1.collider != null) || (hitR2 != null && hitR2.collider != null) || (hitR3 != null && hitR3.collider != null)) {
			stp_r = true;
		} else {
			stp_r  = false;
		}

		// Esquerda
		RaycastHit2D hitL1 = Physics2D.Raycast (new Vector3 (transform.position.x + 0.2f, transform.position.y+ 0.1f),-Vector2.right,0.5f, -5, 0.9f,1.1f);
		RaycastHit2D hitL2 = Physics2D.Raycast (new Vector3 (transform.position.x + 0.2f, transform.position.y + 1f),-Vector2.right,0.5f, -5, 0.9f,1.1f);
		RaycastHit2D hitL3 = Physics2D.Raycast (new Vector3 (transform.position.x + 0.2f, transform.position.y + 1.75f),-Vector2.right,0.5f, -5, 0.9f,1.1f);
		
		Debug.DrawRay (new Vector3 (transform.position.x + 0.175f, transform.position.y + 0.1f),-Vector2.right,Color.blue);
		Debug.DrawRay (new Vector3 (transform.position.x + 0.175f, transform.position.y + 1f),-Vector2.right,Color.blue);
		Debug.DrawRay (new Vector3 (transform.position.x + 0.175f, transform.position.y + 1.75f),-Vector2.right,Color.blue);
		
		if ((hitL1 != null && hitL1.collider != null) || (hitL2 != null && hitL2.collider != null) || (hitL3 != null && hitL3.collider != null)) {
			stp_l = true;
		} else {
			stp_l  = false;
		}

		Debug.DrawRay (transform.position, -Vector3.up, Color.red);
		Debug.DrawRay (new Vector3 (transform.position.x - 0.175f, transform.position.y), -Vector2.up,Color.green);
		Debug.DrawRay (new Vector3 (transform.position.x + 0.175f, transform.position.y), -Vector2.up,Color.green);
		if (hit != null && hit.collider != null) {
			if ((hit.collider.tag == "Floor")) {
				OnGround = true;
			} else {
				OnGround = false;
			}
		} else {
			if ((hitfix_1 != null && hitfix_1.collider != null) || (hitfix_2 != null && hitfix_2.collider != null)) {
				OnGround = true;
			} else {
				OnGround = false;
			}
		}

		RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -Vector2.up, max_height,-5,0.9f,1.1f);
		if (hit2 != null && hit2.collider != null) {
			if (hit2.collider.tag == "Floor") {
				MaxDistance = true;
				max_height = maxH;
			}
		} else {
			MaxDistance = false;
		}

		// Checando Colisões -- Fim

		// Flutuar (se estiver no chao,apertar barra de espaço e poder se mover)
		if (can_move) {
			TheFlight ();
		}
		// Movimentaçao Horizontal -- Inicio

		// Define As Condiçoes Para Andar
		if (can_move) {
			if (flying) {
				side [0] = ((Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow)) && (bln.transform.position.x - 1f < transform.position.x));
				side [1] = ((Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.RightArrow)) && (bln.transform.position.x + 1f > transform.position.x));
			} else {
				side [0] = (Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow));
				side [1] = ((Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.RightArrow)));
			}
		} else {
			if (!cinematic){
				side [0] = false;
				side [1] = false;
			} 
		}

		// Chama a Funçao De Movimento
		TheAxis ();

		// -- Fim
		// velocidade maxima de queda
		move_y = rigidbody2D.velocity.y;
		if (move_y < max_fall) {
			rigidbody2D.velocity = new Vector2 (0, max_fall);
		}
	}

	// Funçao De Levitaçao

	void TheFlight() {
		if (OnGround) {
			canFly = true;
			if ((fly_audio) && (!flying)){
				fly_audio = false;
			}
			if ((fall) && (!speed)){
				rigidbody2D.velocity = new Vector2 (0,-1f);
				fall = false;
			} else {
				fall = false;
			}
		} else if (!flying) {
			canFly = false;
			if (onGreen){
				rigidbody2D.AddForce (new Vector2 (0,jmp_speed/1.5f));
			} else {
				rigidbody2D.AddForce (new Vector2 (0,jmp_speed/3f));
			}
		}
		if (canFly) {
			if ((Input.GetKey(KeyCode.Space)) && (!fall)){
				if ((!audio.isPlaying) && (!fly_audio)){
					audio.PlayDelayed (0.3f);
				}
				timer[1] = Mathf.Lerp (timer[1],1f,0.4f);
				if (timer[1] >= 0.999f){
					timer[1] = 1;
				}
				if (timer[1] == 1f){
					flying = true;
				}
				drag.transform.position = new Vector2 (transform.position.x + (0.5f * transform.localScale.x),transform.position.y + 1.64f);
				bln.transform.rotation = new Quaternion (0,0,0,0);
				GameObject.FindGameObjectWithTag("plr_bln").GetComponent<Rigidbody2D>().fixedAngle = true;
				GameObject.FindGameObjectWithTag("plr_bln").GetComponent<SpringJoint2D>().frequency = 5f;
				resize = Mathf.Lerp(resize,2,0.05f);
				if (resize >= 1.199f){
					resize = 1.2f;
				}
				bln.transform.localScale = new Vector2 (resize * transform.localScale.x,resize + 0.3f);
				if (move_x != 0){
					timer[0] = Mathf.Lerp (timer[0],1f,0.4f);
					if (timer[0] >= 0.999f){
						timer[0] = 1;
					}
					bln.rigidbody2D.AddForce (new Vector2 (300f * transform.localScale.x, 150f));
				} else {
					timer[0] = 0f;
				}
			} else {
				timer [0] = 0;
				timer [1] = 0;
				flying = false;
				fall = true;
				drag.transform.position = new Vector2 (transform.position.x + (-1f * transform.localScale.x),transform.position.y + 1.24f);
				GameObject.FindGameObjectWithTag("plr_bln").GetComponent<Rigidbody2D>().fixedAngle = false;
				GameObject.FindGameObjectWithTag("plr_bln").GetComponent<SpringJoint2D>().frequency = 2f;
				resize = Mathf.Lerp(resize,0.8f,0.05f);
				if (resize <= 0.899f){
					resize = 0.8f;
				}
				bln.transform.localScale = new Vector2 (resize * transform.localScale.x,resize + 0.2f);
				bln.rigidbody2D.AddForce (new Vector2 (0, 150f));
			}
		}
		if (flying){
			if (MaxDistance){
				rigidbody2D.AddForce (new Vector2 (0,jmp_speed));
				fly_audio = true;
			} else {
				canFly = false;
				flying = false;
				fall = true;
				fly_audio = false;
				audio.Stop();
				/*
				stp = move_y;
				stp = Mathf.Lerp(stp,0,0.15f);
				if (stp < 0.001f){
					rigidbody2D.velocity = new Vector2 (0,0);
				} else {
					rigidbody2D.velocity = new Vector2 (0,stp);
				}
				*/
			}
		}
	}

	// Funçao De Movimentaçao Horizontal

	void TheAxis(){

		// Pegando as condiçoes
		if ((side[0]) && (!stp_l)){
			key_left = -1;
			lerp_fix = -1;
		} else {
			key_left = 0;
		}
		if ((side[1]) && (!stp_r)){
			key_right = 1;
			lerp_fix = 1;
		} else {
			key_right = 0;
		}

		move_x = key_left + key_right;
		if (move_x != 0){
			if (move_x > 0){

				// evitando deslise
				if (hsp < 0){
					hsp = 0;
					timer[0] = 0f;
				}
				// aki poderia ser resolvido com outra coisa,mas nao vem em minha mente
				if (hsp < max_speed){
					hsp += mov_speed;
				} else {
					hsp = max_speed;
				}
			}
			if (move_x < 0){

				// evitando deslise
				if (hsp > 0){
					hsp = 0;
					timer[0] = 0f;
				}
				// aki poderia ser resolvido com outra coisa,mas nao vem em minha mente #2
				if (hsp > -max_speed){
					hsp -= mov_speed;
				} else {
					hsp = -max_speed;
				}
			}
		} else {
			hsp = Mathf.Lerp(hsp,0,0.15f);
			if (lerp_fix > 0){
				if (hsp < 0.0001f){
					hsp = 0;
					lerp_fix = 0;
				}
			}
			if (lerp_fix < 0){
				if (hsp > -0.0001f){
					hsp = 0;
					lerp_fix = 0;
				}
			}
		}

		if ((flying) && (timer[0] == 1f)) {
			transform.position = new Vector2 (transform.position.x + hsp / 15, transform.position.y);
		} else if ((OnGround) || (!canFly)){
			transform.position = new Vector2 (transform.position.x + hsp / 10, transform.position.y);
		}
	}
}
