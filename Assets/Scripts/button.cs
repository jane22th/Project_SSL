using UnityEngine;
using System.Collections;
using Flag;

public class Button : Controller {

	void OnMouseDown(){
		string name = gameObject.name;
		if (Flag.Button.get () == Flag.Button.FlagButton.BUTTON_INACTIVITY) {
			if (name.Equals ("button_right_top"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_ATTACK);
			else if (name.Equals ("button_right_bottom"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_DEFENSE);
			else if(name.Equals ("button_left_top"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_CHARGE);
			else if(name.Equals("button_left_bottom"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_REPLACE);
			else if(name.Equals ("sub_body_left"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_LSKILL);
			else if(name.Equals ("sub_body_right"))
				Flag.Button.set (Flag.Button.FlagButton.BUTTON_RSKILL);
			else
				Debug.Log ("ERROR : not exist Button");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
