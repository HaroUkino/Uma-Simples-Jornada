using UnityEngine;
using System.Collections;


public class ColorPick : MonoBehaviour {
	
	public Texture2D c_tex;
	public SpriteRenderer spr;
	public bool changing;

	private Rect lerect = new Rect (Screen.width/2 + 5f,0,Screen.width/2,Screen.height);

	void OnGUI(){
		GUI.DrawTexture (lerect,c_tex);
		if (!changing) {
			return;
		} else {
			if (Event.current.type == EventType.mouseUp) {
				Vector2 ms_pos = Event.current.mousePosition;

				if (ms_pos.x < lerect.x || ms_pos.x > lerect.xMax || ms_pos.y < lerect.y || ms_pos.y > lerect.yMax) {
					return;
				}
				float TexUPos = (ms_pos.x - lerect.x) / lerect.width;
				float TexVPos = 1f - ((ms_pos.y - lerect.y) / lerect.height);

				Color texCol = c_tex.GetPixelBilinear (TexUPos, TexVPos);

				if (texCol.a < 1){
					return;
				}

				spr.color = texCol;
				PlayerPrefs.SetFloat ("R", spr.color.r);
				PlayerPrefs.SetFloat ("G", spr.color.g);
				PlayerPrefs.SetFloat ("B", spr.color.b);
			}
		}
	}
}
