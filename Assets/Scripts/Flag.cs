using UnityEngine;
using System.Collections;

namespace Flag{
	public class Button : MonoBehaviour {
		static FlagButton m_button;
		public const float m_button_time = 3.0f;

		public enum FlagButton{
			BUTTON_INACTIVITY = 0,
			BUTTON_ATTACK = 1<<0,
			BUTTON_DEFENSE = 1<<1,
			BUTTON_CHARGE = 1<<2,
			BUTTON_REPLACE = 1<<3,
			BUTTON_LSKILL = 1<<4,
			BUTTON_RSKILL = 1<<5
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
			STATE_ATTACKING = 1<<0
		};

		public enum Race{
			Kim = 0,
			Lee = 1
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
}
