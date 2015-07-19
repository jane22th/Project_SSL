using UnityEngine;
using System.Collections;
using Flag;

public class Controller : MonoBehaviour {
	Races m_race;

	void Start() {
		m_race = GetComponent<Races>();
	}
	void Update () {
		if (Flag.Button.get () != Flag.Button.FlagButton.BUTTON_NOTHING) {
			Flag.Character.init (m_race.m_state);
			if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_ATTACK)) {
				Flag.Button.reset (Flag.Button.FlagButton.BUTTON_ATTACK);
				Flag.Character.set (Flag.Character.FlagState.STATE_ATTACKING);
			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_DEFENSE)) {
				Flag.Button.reset (Flag.Button.FlagButton.BUTTON_DEFENSE);
				Flag.Character.set (Flag.Character.FlagState.STATE_DEFENSING);
			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_CHARGE)) {
				Flag.Button.reset (Flag.Button.FlagButton.BUTTON_CHARGE);
				Flag.Character.set (Flag.Character.FlagState.STATE_CHARGING);
			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_REPLACE)) {

			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_LSKILL)) {

			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_RSKILL)) {

			}
			m_race.m_state = Flag.Character.get ();
			StartCoroutine(clearButton(Flag.Button.m_button_time));
		}
	}

	IEnumerator clearButton(float time){
		yield return new WaitForSeconds (time);
		Flag.Button.clear ();
	}
}
