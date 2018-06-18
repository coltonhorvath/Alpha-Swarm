using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanNumbers : MonoBehaviour {

    Text humanText;

	// Use this for initialization
	void Start () {
        humanText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void textUpdate (float value) {
        humanText.text = Mathf.Round(value).ToString();
	}
}
