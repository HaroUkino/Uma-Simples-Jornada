//criado por Pedro Henrique (HaroUkino) haroukino@hotmail.com

using UnityEngine;
using System.Collections;

public class KeepinItCool : MonoBehaviour {

	public Transform[] limit;

	public Transform MaxFall;
	public Transform CheckPoint;
	public bool pause;
	public bool can_pause;

	float a;
	float timer;
	float key_left,key_right,key_up,key_down,vm,hm = 0;
	bool[] side = new bool[] {false,false,false,false};

	Vector3 initial_pos;
	PlayerMove plr_mov;
	Camera cam;
	Transform cam_pos;
	// Use this for initialization
	void Start () {

		plr_mov = GetComponent<PlayerMove> ();
		cam = GameObject.Find ("PauseCamera").GetComponent<Camera> ();
		cam_pos = GameObject.Find ("PauseCamera").GetComponent<Transform> ();
		initial_pos = transform.position;
		transform.position = initial_pos;
		PlayerPrefs.SetInt ("tuto1",0);
	}
	
	// Update is called once per frame
	void Update () {
		initial_pos = transform.position;
		if (transform.position.y < MaxFall.position.y) {
			transform.position = CheckPoint.position;
		}

		if (!can_pause){
			return;
		}

		if ((Input.GetKeyDown(KeyCode.M)) || (Input.GetKeyDown (KeyCode.Escape))){
			if ((!pause) && (!plr_mov.dialog) && (!plr_mov.cinematic)) {
				pause = true;
				plr_mov.can_move = false;
				plr_mov.flying = false;
				GameObject.Find("BlackScreen").GetComponent<Intro>().status = 2;
				GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
				GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = true;
			} else if (pause) {
				pause = false;
				plr_mov.can_move = true;
				GameObject.Find("BlackScreen").GetComponent<Intro>().status = 1;
				GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = true;
			}
		}

		if (pause) {
			GameObject[] btn = GameObject.FindGameObjectsWithTag ("psd");
			foreach (GameObject psd in btn) {
				psd.GetComponent<PsdBtns> ().GP = true;
			}
		} else {
			GameObject[] btn = GameObject.FindGameObjectsWithTag ("psd");
			foreach (GameObject psd in btn) {
				psd.GetComponent<PsdBtns> ().GP = false;
			}
			GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

	void FixedUpdate(){
		if ((plr_mov.move_x == 0) && (plr_mov.flying == false) && (!pause) && (!plr_mov.dialog) && (!GameObject.Find("aviso1").GetComponent<TutoStats>().above) && (PlayerPrefs.GetInt("tuto1") == 1) && (!plr_mov.cinematic)) {
			timer = Mathf.Lerp (timer, 100f, Time.deltaTime);
			if (transform.localScale.x == 1){
				GameObject.Find ("menu").transform.localScale = new Vector2 (1,1);
			} else {
				GameObject.Find ("menu").transform.localScale = new Vector2 (-1,1);
			}

			if (timer > 99.5f) {
				a = Mathf.Lerp (a, 1f, Time.deltaTime * 2);
				GameObject.Find ("menu").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, a);
			}
		} else {
			a = 0;
			timer = 0;
			GameObject.Find ("menu").GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
		}
	}
}
