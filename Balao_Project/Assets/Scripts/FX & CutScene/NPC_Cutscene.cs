using UnityEngine;
using System.Collections;

public class NPC_Cutscene : MonoBehaviour {

	public float reaction;
	public bool look;
	public Sprite Alert;
	public GameObject self_bln;
	public Sprite Bln;
	public Transform lepos;

	private bool[] le_alert = new bool[] {false,false,false,false};
	private float tempo_criaçao;
	private float intervalo;

	// Use this for initialization
	void Start () {
		intervalo = 1.5f;
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (Random.Range(0,1f),Random.Range(0,1f),Random.Range(0,1f));
	}
	
	// Update is called once per frame
	void Update () {
		if (look) {
			if (transform.position.x > lepos.position.x){
				transform.localScale = new Vector2 (-1f,1f);
			} else if (transform.position.x < lepos.position.x){
				transform.localScale = new Vector2 (1f,1f);
			}
			if (!le_alert[0]){
				tempo_criaçao = Time.time;
				GameObject obj_0 = new GameObject();
				obj_0.AddComponent<SpriteRenderer>();
				obj_0.AddComponent<Ballon_spawn>();
				obj_0.GetComponent<Ballon_spawn>().begone = true;
				obj_0.GetComponent<SpriteRenderer>().sprite = Alert;
				obj_0.GetComponent<SpriteRenderer>().sortingOrder = 5;
				obj_0.transform.parent = transform;
				obj_0.transform.position = new Vector2(transform.position.x,transform.position.y + 3.5f); 
				obj_0.transform.localScale = new Vector2 (0,0);
				obj_0.tag = "Icon";
				obj_0.name = "Whos There";
				le_alert[0] =  true;
			}
			if (intervalo < Time.time - tempo_criaçao && !(le_alert[1])){
				/*
				 GameObject[] ballon_icon =  GameObject.FindGameObjectsWithTag("Icon");
				foreach (GameObject icon in ballon_icon){
					Destroy (icon);
				}
				*/
				le_alert [1] = false;
			}
			if (intervalo * (2 + reaction) < Time.time - tempo_criaçao && !(le_alert[2])){
				/*
				GameObject icon = GameObject.Find("Icon");
				if (icon == null){
					GameObject[] lebln = GameObject.FindGameObjectsWithTag("balao");
					foreach(GameObject lablon in lebln){
						lablon.GetComponent<SpriteRenderer>().sprite = Bln;
					}
				}
				*/
				GetComponent<Animator>().SetBool("happy",true);
				self_bln.GetComponent<SpriteRenderer>().sprite = Bln;
				le_alert[2] = true;
			}
		}
	}
}
