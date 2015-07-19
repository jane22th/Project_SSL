using UnityEngine;
using System.Collections;

namespace Flag{
	public class Utility : MonoBehaviour {
		public static GameObject makeColliderObject(int race, string name, string tag, Vector3 pos, int dir)
		{
			GameObject base_collider = GameObject.Find ("base_collider");
			Instantiate (base_collider);
			
			//read player data
			Flag.Character.Race data_race = (Flag.Character.Race)race;
			GameObject obj = GameObject.Find ("base_collider(Clone)");
			obj.name = name;
			obj.tag = tag;
			obj.transform.position = pos;
			SpriteRenderer obj_sprite = obj.AddComponent<SpriteRenderer>();
			
			int MAX_SPRITE;
			Flag.Character.Direction data_direction = (Flag.Character.Direction)dir;
			
			switch(data_race){
			case Flag.Character.Race.Kim:
				MAX_SPRITE = 56;
				obj.AddComponent<Kim>();
				for(int i=0;i<=MAX_SPRITE;i++)
					Scene.m_character_kim_ = Resources.LoadAll("human_kim_motion");
				switch(data_direction){
				case Flag.Character.Direction.TopLeft:
					obj_sprite.sprite = (Sprite)Scene.m_character_kim_[2];
					break;
				case Flag.Character.Direction.TopRight:
					obj_sprite.sprite = (Sprite)Scene.m_character_kim_[1];
					break;
				case Flag.Character.Direction.BottomLeft:
					obj_sprite.sprite = (Sprite)Scene.m_character_kim_[3];
					break;
				case Flag.Character.Direction.BottomRight:
					obj_sprite.sprite = (Sprite)Scene.m_character_kim_[4];
					break;
				}
				break;
			case Flag.Character.Race.Lee:
				MAX_SPRITE = 56;
				obj.AddComponent<Lee>();
				for(int i=0;i<=MAX_SPRITE;i++)
					Scene.m_character_lee_ = Resources.LoadAll("human_lee_motion");
				switch(data_direction){
				case Flag.Character.Direction.TopLeft:
					obj_sprite.sprite = (Sprite)Scene.m_character_lee_[2];
					break;
				case Flag.Character.Direction.TopRight:
					obj_sprite.sprite = (Sprite)Scene.m_character_lee_[1];
					break;
				case Flag.Character.Direction.BottomLeft:
					obj_sprite.sprite = (Sprite)Scene.m_character_lee_[3];
					break;
				case Flag.Character.Direction.BottomRight:
					obj_sprite.sprite = (Sprite)Scene.m_character_lee_[4];
					break;
				}
				break;
			default:
				Debug.Log ("ERROR : make data");
				break;
			}

			Races obj_race = obj.GetComponent<Races>();
			obj_race.m_direction = data_direction;
			obj_race.m_race = data_race;

			if (name.Equals ("player")) {
				obj.AddComponent<Controller>();
			} else if(name.Equals("enemy")){
				obj.AddComponent<AI>();
			}

			return obj;
		}	
	}
	public class Button : MonoBehaviour {
		static FlagButton m_button;
		public const float m_button_time = 1.0f;

		public enum FlagButton{
			BUTTON_NOTHING = 0,
			BUTTON_INACTIVITY = 1<<0,
			BUTTON_ATTACK = 1<<1,
			BUTTON_DEFENSE = 1<<2,
			BUTTON_CHARGE = 1<<3,
			BUTTON_REPLACE = 1<<4,
			BUTTON_LSKILL = 1<<5,
			BUTTON_RSKILL = 1<<6
		};

		public static void set(FlagButton f){
			m_button |= f;
		}
		
		public static void reset(FlagButton f){
			m_button &= ~f;
		}

		public static bool check(FlagButton f){
			return ((m_button & f) != 0);
		}

		public static FlagButton get(){
			return m_button;
		}

		public static void clear(){
			m_button = 0;
		}
	}

	public class Character : MonoBehaviour {
		static FlagState m_state;

		public enum FlagState{
			STATE_NOTHING = 0,
			STATE_ATTACKING = 1<<0,
			STATE_DEFENSING = 1<<1,
			STATE_CHARGING = 1<<2
		};

		public enum Race{
			Kim = 0,
			Lee = 1
		};

		public enum Direction{
			TopLeft = 0,
			TopRight = 1,
			BottomLeft = 2,
			BottomRight = 3
		}

		public static void set(FlagState f){
			m_state |= f;
		}
		
		public static void reset(FlagState f){
			m_state &= ~f;
		}
		
		public static bool check(FlagState f){
			return ((m_state & f) != 0);
		}
		
		public static FlagState get(){
			return m_state;
		}

		public static void init(FlagState f){
			m_state = f;
		}

	}
	
	public class Face : MonoBehaviour {
		static FlagFaceState m_state;
		
		public enum FlagFaceState{
			STATE_BLINK = 1<<1,
			STATE_ATTACK = 1<<2,
			STATE_TELL = 1<<3,
			STATE_CHARGE = 1<<4,
			STATE_DANGER = 1<<5,
			STATE_HIT = 1<<6
		};
		
		public static void set(FlagFaceState f){
			m_state |= f;
		}
		
		public static void reset(FlagFaceState f){
			m_state &= ~f;
		}
		
		public static bool check(FlagFaceState f){
			return ((m_state & f) != 0);
		}
		
		public static FlagFaceState get(){
			return m_state;
		}
		
		public static void init(FlagFaceState f){
			m_state = f;
		}
	}
	public class PhysicalBody : MonoBehaviour {
		static FlagState m_state;

		public enum FlagState{
			STATE_NOTHING = 0,
			STATE_ENTER = 1<<0,
			STATE_STAY = 1<<1,
			STATE_END = 1<<2
		};

		public static void set(FlagState f){
			m_state |= f;
		}
		
		public static void reset(FlagState f){
			m_state &= ~f;
		}
		
		public static bool check(FlagState f){
			return ((m_state & f) != 0);
		}
		
		public static FlagState get(){
			return m_state;
		}
		
		public static void init(FlagState f){
			m_state = f;
		}
	}
}
