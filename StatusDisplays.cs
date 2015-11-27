using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusDisplays : MonoBehaviour {
	private Text gameTime, cashBalance;
	// Use this for initialization
	void Start () {
		gameTime = GameObject.Find("GameTime").GetComponent<Text>();
		cashBalance = GameObject.Find("CashBalance").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		gameTime.text = Time.time.ToString();
		cashBalance.text = "£1,000,000";
	}
}
