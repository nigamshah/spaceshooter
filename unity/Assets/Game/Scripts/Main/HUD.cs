using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	private GUIText m_scoreLabel;
	private GUIText m_livesLabel;
	private GUIText m_calloutLabel;

	// Use this for initialization
	void Start () {
		m_scoreLabel = GameObject.Find("Score").guiText;
		m_livesLabel = GameObject.Find("Lives").guiText;
		m_calloutLabel = GameObject.Find("Callout").guiText;

		m_scoreLabel.text = "";
		m_livesLabel.text = "";
		m_calloutLabel.text = "";

		DoCallout("INCOMING WAVE");
	}

	private void ScoreUpdated(int score) {
		m_scoreLabel.text = "SCORE : " + score;
	}

	private void LivesUpdated(int lives) {
		m_livesLabel.text = "LIVES : " + lives;
	}

	private void DoCallout(string callout) {
		DoCallout(callout, 3.0f);
	}
	private void DoCallout(string callout, float time) {
		m_calloutLabel.text = callout;

		if (time > 0) {
			Invoke("ClearCalloutText", time);
		}
	}
	private void ClearCalloutText() {
		m_calloutLabel.text = "";
	}


}
