using UnityEngine;
using System.Collections;

public class KeepinItCool : MonoBehaviour {

	public Transform[] limit;

	public Transform MaxFall;
	public Transform CheckPoint;
	public bool pause;

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
	}
	
	// Update is called once per frame
	void Update () {
		initial_pos = transform.position;
		if (transform.position.y < MaxFall.position.y) {
			transform.position = CheckPoint.position;
		}
		if (Input.GetKeyDown (KeyCode.Escape)){
			Application.Quit();
		}

		if (Input.GetKeyDown(KeyCode.M)){
			if ((!pause) && (!plr_mov.dialog)) {
				cam_pos.position = initial_pos;
				pause = true;
				plr_mov.can_move = false;
				plr_mov.flying = false;
				cam.depth = 1;
			} else if (pause) {
				cam_pos.position = initial_pos;
				pause = false;
				plr_mov.can_move = true;
				cam.depth = -1;
			}
		}
		if (pause) {
			// 0 = left, 1 = right, 2 = up, 3 = down
			side [0] = (Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow));
			side [1] = (Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.RightArrow));
			side [2] = (Input.GetKey (KeyCode.W)) || (Input.GetKey (KeyCode.UpArrow));
			side [3] = (Input.GetKey (KeyCode.S)) || (Input.GetKey (KeyCode.DownArrow));

			// -3 < 5

			if (side[0] && cam_pos.position.x > limit[0].position.x){
				key_left = -1;
			} else {
				key_left = 0;
			}
			if (side[1] && cam_pos.position.x < limit[1].position.x){
				key_right = 1;
			} else {
				key_right = 0;
			}
			hm = key_right + key_left;

			if (side[2] && cam_pos.position.y < limit[2].position.y){
				key_up = 1;
			} else {
				key_up = 0;
			}
			if (side[3] && cam_pos.position.y > limit[3].position.y){
				key_down = -1;
			} else {
				key_down = 0;
			}
			vm = key_up + key_down;

			cam_pos.position = new Vector3 (cam_pos.position.x + (0.5f * hm),
			                                cam_pos.position.y + (0.5f * vm),
			                                - 10f);
		}
	}
}
