using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	const int m_attack = 0;
	const int m_defense = 1;
	const int m_charge = 2;

	Races m_race;

	void Start () {
		m_race = GetComponent<Races> ();
	}

	void Update () {
		//attack, defensing, charging
		if (Scene.tmp == 1) {
			int rand = Random.Range (0, 3);
			rand = 0;
			Flag.Character.init (m_race.m_state);
			switch (rand) {
			case m_attack:
				Debug.Log ("!!");
				Flag.Character.set (Flag.Character.FlagState.STATE_ATTACKING);
				break;
			case m_defense:
				break;
			case m_charge:
				break;
			default:
				Debug.Log ("ERROR : AI");
				break;
			}
			m_race.m_state = Flag.Character.get ();
			Debug.Log (m_race.m_state + name);
		}
		Scene.tmp = 0;
	}
}
