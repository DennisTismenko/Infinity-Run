using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text scoreText;
	public int score;
	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		SetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		SetScore();
	}

	void SetScore() {
		scoreText.text = "Score: " + CalculateScore();
	}

	int CalculateScore(){
		return (int)(Player.scoreMultiplier *Time.time*100 - startTime);
	}
}
