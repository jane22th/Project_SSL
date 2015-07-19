using UnityEngine;
using System.Collections;
using Flag;

public class Face : MonoBehaviour {

	GameObject m_face;
	string m_race;

	Animator animator;
	
	// Use this for initialization
	// This must be started after face object is loaded 
	void Start () {
		// get player
		/*GameObject m_player_object = GameObject.Find (name);
		Player m_player = m_player_object.GetComponent<Player>();

		// get race
		switch (m_player.m_race) {
			case Flag.Character.Race.Kim:
				m_race = "human_kim";
				break;
			case Flag.Character.Race.Lee:
				m_race = "human_lee";
				break;
			default:
				m_race = null;
				break;
		}*/

		// load face object
		//m_face = GameObject.Find (name);
		Flag.Face.init (Flag.Face.FlagFaceState.STATE_BLINK);
		//Flag.Face.set (Flag.Face.FlagFaceState.STATE_BLINK); // set state to blink(basic)

		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("idle") == true) {
			animator.SetInteger ("random_int", Random.Range (0, 3));
		}
		else if (animator.GetCurrentAnimatorStateInfo (0).IsName ("process") == true) {
			executeAnimation (Flag.Face.FlagFaceState.STATE_BLINK);
		}
	}

	public void executeAnimation(Flag.Face.FlagFaceState f) {
		switch (f) {
			case Flag.Face.FlagFaceState.STATE_BLINK:
				animator.SetTrigger("blink");
				break;
			case Flag.Face.FlagFaceState.STATE_ATTACK:
				animator.SetTrigger("attack");
				break;
			case Flag.Face.FlagFaceState.STATE_CHARGE:
				animator.SetTrigger("charge");
				break;
			case Flag.Face.FlagFaceState.STATE_DANGER:
				animator.SetTrigger("danger");
				break;
			case Flag.Face.FlagFaceState.STATE_HIT:
				animator.SetTrigger("hit");
				break;
			case Flag.Face.FlagFaceState.STATE_TELL:
				animator.SetTrigger("tell");
				break;
			default:
				break;
		}
	}
}
