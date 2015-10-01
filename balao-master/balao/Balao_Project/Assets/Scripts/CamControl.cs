
// nesse script faremos a camera serguir objeto que marcarmos,o objeto a sermarcado esta em uma variavel publica,logo podera ser modificado no inspector


using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {
	public Transform[] limites;
	public Transform target;
	public float damped;
	public float h;
	public bool follow;
	public bool Dial;
	public float n_z;
	public float d_z;
	int m;
	float ax_y;
	float ax_x;
	float zoom;
	Camera Cam;
	Transform targeting;
	PlayerMove plr_mov;
	// Use this for initialization
	void Start () {
		Cam = GetComponent<Camera>();
		zoom = n_z;
		plr_mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
		m = 2;
		//transform.position = new Vector3 (target.position.x,target.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			// aqui e onde a camera segue suavemente o objeto alvo
			if (limites.Length > 0){
				if (plr_mov.transform.position.x < limites[m].position.x && plr_mov.transform.position.x > limites[1].position.x){
					ax_x = Mathf.Lerp (transform.position.x, target.position.x, Time.deltaTime * damped);
				} else if (plr_mov.cinematic) {
					ax_x = Mathf.Lerp (transform.position.x, target.position.x, Time.deltaTime * damped);
				}
				if (plr_mov.transform.position.x > limites[4].transform.position.x){
					if (plr_mov.transform.position.y < limites[3].position.y){
						ax_y = Mathf.Lerp (transform.position.y, target.position.y + h, Time.deltaTime * damped);
						m = 2;
					} else {
						m = 5;
					}
				} else {
					if (plr_mov.transform.position.y < limites[0].position.y){
						ax_y = Mathf.Lerp (transform.position.y, target.position.y + h, Time.deltaTime * damped);
						m = 2;
					}
				}
			} else {
				ax_x = Mathf.Lerp (transform.position.x, target.position.x, Time.deltaTime * damped);
				ax_y = Mathf.Lerp (transform.position.y, target.position.y + h, Time.deltaTime * damped);
			}
			transform.position = new Vector3 (ax_x, ax_y, transform.position.z);
			Cam.orthographicSize = zoom;
			if (Dial){
				zoom = Mathf.Lerp(zoom,d_z,0.1f);
				if (zoom < d_z + 0.001f){
					zoom = d_z;
				}
			} else {
				zoom = Mathf.Lerp(zoom,n_z,0.1f);
				if (zoom > n_z - 0.001f){
					zoom = n_z;
				}
			}
		}
	}
}
