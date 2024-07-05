
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoSingleton<UIMain> {

	// Use this for initialization
	protected  override void OnStart () {
	}

    // Update is called once per frame
    void Update () {
		
	}

	public void OnClickTest()
	{
		UIManager.Instance.Show<UITest>();
	}

	public void OnClickGameOver()
	{
		UIManager.Instance.Show<UIGameOver>();
	}
}

