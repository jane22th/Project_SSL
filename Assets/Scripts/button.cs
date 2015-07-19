using UnityEngine;
using System.Collections;
using Flag;

public class Button : Controller {

	void OnMouseDown(){
		string name = gameObject.name;
		if (!Flag.Button.check (Flag.Button.FlagButton.BUTTON_INACTIVITY)) {
			if (name.Equals ("button_right_top")){
				//Flag.Button.set (Flag.Button.FlagButton.BUTTON_ATTACK);
				SpriteRenderer button_sprite = GetComponent<SpriteRenderer>();
				button_sprite.sprite = (Sprite)Scene.m_ui[9];
				GameObject obj = GameObject.Find ("button_attack");
				SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer>();
				attack_sprite.sprite = (Sprite)Scene.m_ui[4];
			}
			else if (name.Equals ("button_right_bottom")){
				//Flag.Button.set (Flag.Button.FlagButton.BUTTON_DEFENSE);
				SpriteRenderer button_sprite = GetComponent<SpriteRenderer>();
				button_sprite.sprite = (Sprite)Scene.m_ui[9];
				GameObject obj = GameObject.Find ("button_defense");
				SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer>();
				attack_sprite.sprite = (Sprite)Scene.m_ui[15];
			}
			else if (name.Equals ("button_left_top")){
				//Flag.Button.set (Flag.Button.FlagButton.BUTTON_CHARGE);
				SpriteRenderer button_sprite = GetComponent<SpriteRenderer>();
				button_sprite.sprite = (Sprite)Scene.m_ui[9];
				GameObject obj = GameObject.Find ("button_charge");
				SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer>();
				attack_sprite.sprite = (Sprite)Scene.m_ui[13];
			}
			else if (name.Equals ("button_left_bottom")){
				//Flag.Button.set (Flag.Button.FlagButton.BUTTON_REPLACE);
				SpriteRenderer button_sprite = GetComponent<SpriteRenderer>();
				button_sprite.sprite = (Sprite)Scene.m_ui[9];
				GameObject obj = GameObject.Find ("button_replace");
				SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer>();
				attack_sprite.sprite = (Sprite)Scene.m_ui[17];
			}/*
			else if (name.Equals ("sub_body_left"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_LSKILL);
			else if (name.Equals ("sub_body_right"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_RSKILL);
			else
				Debug.Log ("ERROR : not exist Button");
			Flag.Button.set (Flag.Button.FlagButton.BUTTON_INACTIVITY);
			Scene.tmp = 1;
			*/
		}
	}

	void OnMouseUp(){
		string name = gameObject.name;
		if (name.Equals ("button_right_top")) {
			Flag.Button.set (Flag.Button.FlagButton.BUTTON_ATTACK);
			SpriteRenderer button_sprite = GetComponent<SpriteRenderer> ();
			button_sprite.sprite = (Sprite)Scene.m_ui [11];
			GameObject obj = GameObject.Find ("button_attack");
			SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer> ();
			attack_sprite.sprite = (Sprite)Scene.m_ui [5];
		} else if (name.Equals ("button_right_bottom")) {
			Flag.Button.set (Flag.Button.FlagButton.BUTTON_DEFENSE);
			SpriteRenderer button_sprite = GetComponent<SpriteRenderer> ();
			button_sprite.sprite = (Sprite)Scene.m_ui [11];
			GameObject obj = GameObject.Find ("button_defense");
			SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer> ();
			attack_sprite.sprite = (Sprite)Scene.m_ui [16];
		} else if (name.Equals ("button_left_top")) {
			Flag.Button.set (Flag.Button.FlagButton.BUTTON_CHARGE);
			SpriteRenderer button_sprite = GetComponent<SpriteRenderer> ();
			button_sprite.sprite = (Sprite)Scene.m_ui [11];
			GameObject obj = GameObject.Find ("button_charge");
			SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer> ();
			attack_sprite.sprite = (Sprite)Scene.m_ui [14];
		} else if (name.Equals ("button_left_bottom")) {
			Flag.Button.set (Flag.Button.FlagButton.BUTTON_REPLACE);
			SpriteRenderer button_sprite = GetComponent<SpriteRenderer> ();
			button_sprite.sprite = (Sprite)Scene.m_ui [11];
			GameObject obj = GameObject.Find ("button_replace");
			SpriteRenderer attack_sprite = obj.GetComponent<SpriteRenderer> ();
			attack_sprite.sprite = (Sprite)Scene.m_ui [18];
		} else if (name.Equals ("sub_body_left"))
			Flag.Button.set (Flag.Button.FlagButton.BUTTON_LSKILL);
		else if (name.Equals ("sub_body_right"))
			Flag.Button.set (Flag.Button.FlagButton.BUTTON_RSKILL);
		else
			Debug.Log ("ERROR : not exist Button");
		Flag.Button.set (Flag.Button.FlagButton.BUTTON_INACTIVITY);
		Scene.tmp = 1;
	}

	void Update () {
	
	}
}
