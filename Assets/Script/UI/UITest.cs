using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : UIWindow {

	public Text text;
	// Use this for initialization
	void Start () {
		this.SetTitle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTitle () 
	{
		text.text = "hello";
	}
}
