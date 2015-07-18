using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
	public static Object[] m_character_kim_;
	public static Object[] m_character_lee_;
	public static Vector3[] init_position;
	public static Object[] m_ui;
	GameObject player;
	GameObject enemy;
	//data
	public static int tmp = 0;
	void Start () {
		int MAX_SPRITE;
		//make scene : read data
		init_position = new Vector3[4];
		init_position[(int)Flag.Character.Direction.BottomLeft] = new Vector3 (-1.67f, 1.78f, 11.78f);
		init_position [(int)Flag.Character.Direction.TopRight] = new Vector3(1.52f, 3.38f, 13.38f);

		//object
		player = Flag.Utility.makeColliderObject (0, "player", "Player", new Vector3 (-1.67f, 1.78f, 11.78f), 2);
		enemy = Flag.Utility.makeColliderObject (1, "enemy", "Untagged", new Vector3(1.52f, 3.38f, 13.38f), 1);

		//UI
		MAX_SPRITE = 29;
		for(int i=0;i<=MAX_SPRITE;i++)
			Scene.m_ui = Resources.LoadAll("human_ui");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
