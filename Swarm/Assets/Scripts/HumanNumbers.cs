using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnNumbers : MonoBehaviour {

    Text spawnText;

	// Use this for initialization
	void Start () {
        spawnText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void textUpdate (float value) {
        spawnText.text = Mathf.Round(value).ToString();
	}
}
