using UnityEngine;
using System.Collections;

public class MainNum : MonoBehaviour {

	public Rect btns;
	public Rect results;

	private int a,b,c,d,e,f,g,h,i;
	private bool[] r = new bool[] {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};

	void Update(){
		if (r [0])
			a--;
		if (r [1])
			a++;
		if (r [2])
			b--;
		if (r [3])
			b++;
		if (r [4])
			c--;
		if (r [5])
			c++;
		if (r [6])
			d--;
		if (r [7])
			d++;
		if (r [8])
			e--;
		if (r [9])
			e++;
		if (r [10])
			f--;
		if (r [11])
			f++;
		if (r [12])
			g--;
		if (r [13])
			g++;
		if (r [14])
			h--;
		if (r [15])
			h++;
		if (r [16])
			i--;
		if (r [17])
			i++;
		if (r [18]){
			a = 0;b = 0;c = 0;d = 0;e = 0;f = 0;g = 0;h = 0;i = 0;
		}

	}

	void OnGUI(){
		// butoes 
		// reset
		r [18] = GUI.Button (new Rect (btns.x * 10, btns.y, 50f, 20f), "reset");

		// a
		r[0] = GUI.Button (btns, "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y,btns.width,btns.height), a.ToString());
		r[1] = GUI.Button (new Rect(btns.x + 50f,btns.y,btns.width,btns.height), "+");

		// b
		r[2] = GUI.Button (new Rect(btns.x,btns.y + 30f ,btns.width,btns.height), "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y + 30f,btns.width,btns.height), b.ToString());
		r[3] = GUI.Button (new Rect(btns.x + 50f,btns.y + 30f,btns.width,btns.height), "+");

		// c
		r[4] = GUI.Button (new Rect(btns.x,btns.y + 60f ,btns.width,btns.height), "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y + 60f,btns.width,btns.height), c.ToString());
		r[5] = GUI.Button (new Rect(btns.x + 50f,btns.y + 60f,btns.width,btns.height), "+");

		// d
		r[6] = GUI.Button (new Rect(btns.x,btns.y + 90f ,btns.width,btns.height), "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y + 90f,btns.width,btns.height), d.ToString());
		r[7] = GUI.Button (new Rect(btns.x + 50f,btns.y + 90f,btns.width,btns.height), "+");

		// e
		r[8] = GUI.Button (new Rect(btns.x,btns.y + 120f ,btns.width,btns.height), "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y + 120f,btns.width,btns.height), e.ToString());
		r[9] = GUI.Button (new Rect(btns.x + 50f,btns.y + 120f,btns.width,btns.height), "+");

		// f
		r[10] = GUI.Button (new Rect(btns.x,btns.y + 150f ,btns.width,btns.height), "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y + 150f,btns.width,btns.height), f.ToString());
		r[11] = GUI.Button (new Rect(btns.x + 50f,btns.y + 150f,btns.width,btns.height), "+");

		// g
		r[12] = GUI.Button (new Rect(btns.x,btns.y + 180f ,btns.width,btns.height), "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y + 180f,btns.width,btns.height), g.ToString());
		r [13] = GUI.Button (new Rect (btns.x + 50f, btns.y + 180f, btns.width, btns.height), "+");

		// h
		r [14] = GUI.Button (new Rect (btns.x, btns.y + 210f, btns.width, btns.height), "-");
		GUI.Label (new Rect (btns.x + 30f, btns.y + 210f, btns.width, btns.height), h.ToString ());
		r [15] = GUI.Button (new Rect (btns.x + 50f, btns.y + 210f, btns.width, btns.height), "+");

		// i
		r[16] = GUI.Button (new Rect(btns.x,btns.y + 240f ,btns.width,btns.height), "-");
		GUI.Label (new Rect(btns.x + 30f,btns.y + 240f,btns.width,btns.height), i.ToString());
		r [17] = GUI.Button (new Rect (btns.x + 50f, btns.y + 240f, btns.width, btns.height), "+");


		// resultados
		GUI.Label (results,a.ToString() + " + " + b.ToString() + " - " + c.ToString() + " = " + (a+b-c).ToString() + "     '4'");
		GUI.Label (new Rect(results.x,results.y + 30f,results.width,results.height),d.ToString() + " - " + e.ToString() + " + " + f.ToString() + " = " + (d-e+f).ToString() + "     '8'");
		GUI.Label (new Rect(results.x,results.y + 60f,results.width,results.height),g.ToString() + " * " + h.ToString() + " - " + i.ToString() + " = " + (g*h-i).ToString() + "     '8'");

	}
}
