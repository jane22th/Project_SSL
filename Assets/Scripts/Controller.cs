using UnityEngine;
using System.Collections;
using Flag;

public class Controller : MonoBehaviour {
	GameObject m_player_object;
	Player m_player;

	void Start() {
		m_player_object = GameObject.Find ("player");
		m_player = m_player_object.GetComponent<Player>();
	}
	void Update () {
		if (Flag.Button.get () != Flag.Button.FlagButton.BUTTON_INACTIVITY) {
			Flag.Character.init (m_player.m_state);
			if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_ATTACK)) {
				Flag.Character.set (Flag.Character.FlagState.STATE_ATTACKING);
			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_DEFENSE)) {

			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_CHARGE)) {

			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_REPLACE)) {

			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_LSKILL)) {

			} else if (Flag.Button.check (Flag.Button.FlagButton.BUTTON_RSKILL)) {

			}
			m_player.m_state = Flag.Character.get ();
			StartCoroutine(clearButton(Flag.Button.m_button_time));
		}
	}

	IEnumerator clearButton(float time){
		yield return new WaitForSeconds (time);
		Flag.Button.clear ();
	}
}
