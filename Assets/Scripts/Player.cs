using UnityEngine;
using System.Collections;
using Flag;

public class Player : MonoBehaviour {
	public Flag.Character.Race m_race;
	public Flag.Character.FlagState m_state;

	void Start () {
		m_race = Flag.Character.Race.Kim;
		switch (m_race) {
		case Flag.Character.Race.Kim:
			gameObject.AddComponent<Kim>();
			break;
		default:
			Debug.Log ("ERROR : not exist race");
			break;
		}
		m_state = 0;
	}

	Vector3 normalize(Vector3 v){
		float tmp = Mathf.Sqrt (v.x*v.x + v.y*v.y);
		return v / tmp;
	}

	void applyPlayerState() {
		Flag.Character.init (m_state);
		if (Flag.Character.check (Flag.Character.FlagState.STATE_ATTACKING)) {
			GameObject enemy_object = GameObject.Find ("enemy");
			Vector3 direction = enemy_object.transform.position - transform.position;
			direction = normalize (direction);

		}
		m_state = Flag.Character.get ();
	}

	void Update () {
		applyPlayerState ();
	}
}
