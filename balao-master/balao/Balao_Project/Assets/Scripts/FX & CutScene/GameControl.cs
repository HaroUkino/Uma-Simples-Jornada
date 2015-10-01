/// <summary>
/// Script Criado Por Pedro Henrique (Haro Ukino) xiunnob@gmail.com
/// </summary>

using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public Transform[] interest_points;
	public Sprite[] Dial_Itens;
	public bool[] CheckIn = new bool[]{false,false,false,false,false};

	private float tempo_intervalo = 1.5f;
	private float tempo_criaçao;
	private float[] timer = new float[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private bool start;
	private bool[] Dial = new bool[] {false,false,false,false,false,false,false,false,false,false,false};

	ComunicationAndStatusPlayer cmt_plr;
	PlayerMove plr_mov;
	NPCMove npc_mov;
	CamControl cam;
	Camera cam_size;
	GameObject[] npcf;

	// Use this for initialization
	void Start () {
		timer[3] = 5f;
		start = false;
		cmt_plr = GameObject.FindGameObjectWithTag("Player").GetComponent<ComunicationAndStatusPlayer>();
		plr_mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
		npc_mov = GameObject.Find("NPCF").GetComponent<NPCMove>();
		cam = GameObject.Find ("Main Camera").GetComponent<CamControl> ();
		cam_size = GameObject.Find ("Main Camera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((cmt_plr.stats_value == 6) && (!CheckIn[4])) {
			GameObject.Find ("LastLimit").GetComponent<BoxCollider2D>().enabled = false;
			plr_mov.can_move = false;
			plr_mov.side[0] = false;
			plr_mov.side[1] = false;
			plr_mov.cinematic = true;
			start = true;
			CheckIn[4] = true;
		}
		if (start){
			timer[0] = Mathf.Lerp (timer[0],1f,0.05f);
			if (timer[0] > 0.999f){
				timer[0] = 1f;
			}
			if (timer[0] == 1f){
				plr_mov.side[1] =  true;
				start = false;
			}
		}

		if (CheckIn[0]){
			plr_mov.side[1] =  false;
			plr_mov.hsp = 0;
			timer[2] = Mathf.Lerp (timer[2],1f,0.05f);
			if (timer[2] > 0.999f){
				timer[2] = 1f;
			}
			if (timer[2] == 1f){
				//cam.transform.position = new Vector3(interest_points[1].position.x,interest_points[1].position.y,transform.position.z);
				cam.target = interest_points[1];
				if (npc_mov != null){
					npc_mov.side[0] = true;
				}
				CheckIn[0] = false;
			}
		}
		if (CheckIn [1]) {
			cam.follow = false;
			npc_mov.side[0] = false;
			timer[1] = Mathf.Lerp (timer[1],1f,0.1f);
			if (timer[1] > 0.999f){
				timer[1] = 1f;
			}
			if (timer[1] == 1f){
				plr_mov.side[1] = true;
			}
		}

		if (CheckIn[2]){
			plr_mov.side[1] = false;
			plr_mov.hsp = 0;
			npc_mov.side[0] = true;
		}

		if (CheckIn [3]) {
			npc_mov.side [0] = false;
			if (!Dial [10]) {
				timer [3] = Mathf.Lerp (timer [3], 3f, 0.05f);
				cam_size.orthographicSize = timer [3];
				if (timer [3] < 3.001) {
					Dial [10] = true;
				}
			}

			if (!Dial [0]) {
				tempo_criaçao = Time.time;
				GameObject obj_0 = new GameObject (); // Cria Um GameObject Novo
				obj_0.AddComponent<SpriteRenderer> (); // Adiciona o Componente <SpriteRenderer>
				obj_0.AddComponent<Ballon_spawn> (); // Adiciona o Componente <Ballon_spawn> (que no caso e um script)
				obj_0.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [0]; // Mudamos o Sprite Do Objeto
				obj_0.GetComponent<SpriteRenderer> ().sortingOrder = 3;
				obj_0.transform.parent = transform; // Criamos o Objeto(obj_0 -- Vulgo Balao de Dialogo) dentro desse (NPC)
				obj_0.transform.position = new Vector2 (plr_mov.transform.position.x, transform.position.y - 2f); // Definimos Sua Posiçao
				obj_0.transform.localScale = new Vector2 (0, 0); // Definimos Sua Escala (Vulgo Tamanho)
				obj_0.tag = "Icon"; // Damos A Tag "Icon" Para o Objeto
				obj_0.name = "Ballon Dial"; // Nomeamos o Obj
				Dial [0] = true; // Enfim Começamos o Dialogo
			}
			if (tempo_intervalo < Time.time - tempo_criaçao && !(Dial [1])) {
				GameObject obj_1 = new GameObject ();
				obj_1.AddComponent<SpriteRenderer> ();
				obj_1.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [1];
				obj_1.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				obj_1.transform.parent = transform;
				obj_1.transform.position = new Vector2 (plr_mov.transform.position.x - (0.8f * transform.localScale.x), transform.position.y - 0.4f);
				if (transform.localScale.x > 0) { // Aqui Fazemos o Balao Nao Ficar Virado Para Direçao Errada
					obj_1.transform.localScale = new Vector2 (0.6f, 0.8f);
				} else {
					obj_1.transform.localScale = new Vector2 (-0.6f, 0.8f);
				}
				obj_1.tag = "Icon_0";
				obj_1.name = "Ballon Icon Player";
				Dial [1] = true;
			}
			if (tempo_intervalo * 2f < Time.time - tempo_criaçao && !(Dial [2])) {
				GameObject obj_2 = new GameObject ();
				obj_2.AddComponent<SpriteRenderer> ();
				obj_2.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [2];
				obj_2.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				obj_2.transform.parent = transform;
				obj_2.transform.position = new Vector2 (plr_mov.transform.position.x - (2.5f * transform.localScale.x), transform.position.y - 0.4f);
				if (transform.localScale.x > 0) { // Aqui Fazemos o Balao Nao Ficar Virado Para Direçao Errada
					obj_2.transform.localScale = new Vector2 (0.6f, 0.8f);
				} else {
					obj_2.transform.localScale = new Vector2 (-0.6f, 0.8f);
				}
				obj_2.tag = "Icon_0";
				obj_2.name = "Ballon Icon Npc";
				Dial [2] = true;
			}

			if (tempo_intervalo * 3f < Time.time - tempo_criaçao && !(Dial [3])) {
				GameObject obj_3 = new GameObject ();
				obj_3.AddComponent<SpriteRenderer> ();
				obj_3.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [3];
				obj_3.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				obj_3.transform.parent = transform;
				obj_3.transform.position = new Vector2 (plr_mov.transform.position.x - (1.65f * transform.localScale.x), transform.position.y - 0.4f);
				if (transform.localScale.x > 0) { // Aqui Fazemos o Balao Nao Ficar Virado Para Direçao Errada
					obj_3.transform.localScale = new Vector2 (1f, 1f);
				} else {
					obj_3.transform.localScale = new Vector2 (1f, 1f);
				}
				obj_3.tag = "Icon_0";
				obj_3.name = "Witnes Me";
				Dial [3] = true;
			}

			if (tempo_intervalo * 4f < Time.time - tempo_criaçao && !(Dial [4])) {
				GameObject obj_4 = new GameObject ();
				obj_4.AddComponent<SpriteRenderer> ();
				obj_4.AddComponent<FadeAnimation> ();
				obj_4.AddComponent<Rigidbody2D> ();
				obj_4.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [4];
				obj_4.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				obj_4.transform.parent = transform;
				obj_4.transform.position = new Vector2 (plr_mov.transform.position.x + (0.8f * transform.localScale.x), transform.position.y - 1f);
				if (transform.localScale.x > 0) { // Aqui Fazemos o Balao Nao Ficar Virado Para Direçao Errada
					obj_4.transform.localScale = new Vector2 (0.8f, 0.8f);
				} else {
					obj_4.transform.localScale = new Vector2 (0.8f, 0.8f);
				}
				obj_4.tag = "Icon_0";
				obj_4.name = "MEDIOCRE";
				Dial [4] = true;
			}

			if (tempo_intervalo * 5.5f < Time.time - tempo_criaçao && !(Dial [5])) {
				GameObject[] ballon_icon = GameObject.FindGameObjectsWithTag ("Icon_0");
				foreach (GameObject icon in ballon_icon) {
					Destroy (icon);
				}
				Dial [5] = true;
			}

			if (tempo_intervalo * 6f < Time.time - tempo_criaçao && !(Dial [6])) {
				GameObject obj_5 = new GameObject ();
				obj_5.AddComponent<SpriteRenderer> ();
				obj_5.AddComponent<Ballon_spawn> ();
				obj_5.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [6];
				obj_5.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				obj_5.transform.parent = transform;
				obj_5.transform.position = new Vector2 (plr_mov.transform.position.x - (1.65f * transform.localScale.x), transform.position.y - 1f);
				if (transform.localScale.x > 0) { // Aqui Fazemos o Balao Nao Ficar Virado Para Direçao Errada
					obj_5.transform.localScale = new Vector2 (0, 0);
				} else {
					obj_5.transform.localScale = new Vector2 (0, 0);
				}
				obj_5.tag = "Icon_0";
				obj_5.name = "Goin into alert status";
				Dial [6] = true;
			}

			if (tempo_intervalo * 7.5f < Time.time - tempo_criaçao && !(Dial [7])) {
				GameObject[] ballon_icon = GameObject.FindGameObjectsWithTag ("Icon_0");
				foreach (GameObject icon in ballon_icon) {
					Destroy (icon);
				}
				GameObject obj_6 = new GameObject ();
				obj_6.AddComponent<SpriteRenderer> ();
				obj_6.AddComponent<Ballon_spawn> ();
				obj_6.GetComponent<Ballon_spawn> ().direct = true;
				obj_6.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [7];
				obj_6.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				obj_6.transform.parent = transform;
				obj_6.transform.position = new Vector2 (plr_mov.transform.position.x - (1.65f * transform.localScale.x), transform.position.y - 1f);
				if (transform.localScale.x > 0) { // Aqui Fazemos o Balao Nao Ficar Virado Para Direçao Errada
					obj_6.transform.localScale = new Vector2 (0, 0);
				} else {
					obj_6.transform.localScale = new Vector2 (0, 0);
				}
				obj_6.tag = "Icon";
				obj_6.name = "wats worng";
				Dial [7] = true;
			}

			if (tempo_intervalo * 8.5f < Time.time - tempo_criaçao && !(Dial [8])) {
				GameObject[] ballon_icon = GameObject.FindGameObjectsWithTag ("Icon");
				foreach (GameObject icon in ballon_icon) {
					Destroy (icon);
				}
				Dial [8] = true;
			}

			if (tempo_intervalo * 10f < Time.time - tempo_criaçao && !(Dial [9])) {
				GameObject hud = GameObject.Find ("HUD");
				Destroy (hud);
				GameObject obj_7 = new GameObject ();
				obj_7.AddComponent<SpriteRenderer> ();
				obj_7.AddComponent<FadeAnimation> ();
				obj_7.AddComponent<Rigidbody2D> ();
				obj_7.GetComponent<SpriteRenderer> ().sprite = Dial_Itens [5];
				obj_7.GetComponent<SpriteRenderer> ().sortingOrder = 4;
				obj_7.transform.parent = transform;
				obj_7.transform.position = new Vector2 (plr_mov.transform.position.x + (0.8f * transform.localScale.x), transform.position.y - 1f);
				if (transform.localScale.x > 0) { // Aqui Fazemos o Balao Nao Ficar Virado Para Direçao Errada
					obj_7.transform.localScale = new Vector2 (0.8f, 0.8f);
				} else {
					obj_7.transform.localScale = new Vector2 (0.8f, 0.8f);
				}
				obj_7.tag = "Icon";
				obj_7.name = "VAHALLHA";

				timer [3] = Mathf.Lerp (timer [3], 8f, 0.05f);
				cam_size.orthographicSize = timer [3];

				GameObject.FindGameObjectWithTag ("Final_Bln").GetComponent<SpriteRenderer> ().sprite = Dial_Itens [1];

				npcf = GameObject.FindGameObjectsWithTag ("NPC_F");
				foreach (GameObject npf in npcf) {
					npf.GetComponent<NPC_Cutscene> ().look = true;
				}
				Dial [9] = true;
			}
			if (Dial [9]) {
				timer [3] = Mathf.Lerp (timer [3], 8f, 0.05f);
				cam_size.orthographicSize = timer [3];
				if (timer [3] > 7.999f) {
					timer [3] = 8;
					for (int i = 0;i <= 3; i++){
						CheckIn[i] = false;
					}
				}
			}
		} else {
			if (Dial[9]){
				print ("roll credits");
			}
		}
	}
}
