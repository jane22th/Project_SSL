using UnityEngine;
using System.Collections;
using Flag;

public class Races : MonoBehaviour {
	public Flag.Character.Race m_race;
	public Flag.Character.FlagState m_state;
	public Flag.PhysicalBody.FlagState m_physical;
	public Flag.Character.Direction m_direction;	

	public void init(){
		m_state = Flag.Character.FlagState.STATE_NOTHING;
		m_physical = Flag.PhysicalBody.FlagState.STATE_NOTHING;
	}

	public Vector3 normalize(Vector3 v, ref float speed){
		speed = Mathf.Sqrt (v.x*v.x + v.y*v.y);
		return v / speed;
	}

	void OnTriggerEnter2D(Collider2D other){
		Flag.PhysicalBody.init (m_physical);
		Flag.PhysicalBody.set (Flag.PhysicalBody.FlagState.STATE_ENTER);
		m_physical = Flag.PhysicalBody.get ();
	}

	bool checkInitPosition(){
		if (m_direction == Flag.Character.Direction.BottomLeft || m_direction == Flag.Character.Direction.TopLeft) {
			if (Scene.init_position [(int)m_direction].x > transform.position.x)
				return true;
		}
		else {
			if (Scene.init_position [(int)m_direction].x < transform.position.x)
				return true;
		}
		return false;
	}

	public void applyState(){
		Flag.Character.init (m_state);
		Flag.PhysicalBody.init (m_physical);
		if (Flag.Character.check (Flag.Character.FlagState.STATE_ATTACKING)) {
			string opponent = name.Equals ("player") ? "enemy" : "player";
			GameObject object_opponent = GameObject.Find (opponent);
			Races race_opponent = object_opponent.GetComponent<Races> ();
			//accelation
			//Vector3 direction = object_opponent.transform.position - transform.position;
			//normal
			Vector3 direction = Scene.init_position [(int)race_opponent.m_direction] - Scene.init_position [(int)m_direction];
			float speed = 0;
			direction = normalize (direction, ref speed);

			if (Flag.PhysicalBody.check (Flag.PhysicalBody.FlagState.STATE_ENTER))
				direction = -direction;
			transform.Translate (2 * speed * direction * Time.deltaTime / Flag.Button.m_button_time);

			if(checkInitPosition()){
				transform.position = Scene.init_position [(int)m_direction];
				Flag.Character.reset (Flag.Character.FlagState.STATE_ATTACKING);
				Flag.PhysicalBody.reset (Flag.PhysicalBody.FlagState.STATE_ENTER);
			}

		} else if (Flag.Character.check (Flag.Character.FlagState.STATE_DEFENSING)) {
			if(Flag.PhysicalBody.check (Flag.PhysicalBody.FlagState.STATE_ENTER)){
				Flag.PhysicalBody.reset(Flag.PhysicalBody.FlagState.STATE_ENTER);
			}
			Debug.Log ("Defensing");
		} else if (Flag.Character.check (Flag.Character.FlagState.STATE_CHARGING)) {
			Debug.Log ("Charging");
		}
		m_state = Flag.Character.get ();
		m_physical = Flag.PhysicalBody.get ();
	}
}
