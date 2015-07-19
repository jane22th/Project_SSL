using UnityEngine;
using System.Collections;
using Flag;

public class test : MonoBehaviour {
	int flag = 0;
	// Use this for initialization
	void Start () {
		Face f = new Face ();
		//f.executeAnimation (Flag.Face.FlagFaceState.STATE_ATTACK);
	}
	
	// Update is called once per frame
	void Update () {
		if(flag == 0)
		transform.Translate (new Vector3(0, -0.008f, -0.008f));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("!enter");
		flag = 1;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		//Debug.Log ("stay!");
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("exit");
	}
}
