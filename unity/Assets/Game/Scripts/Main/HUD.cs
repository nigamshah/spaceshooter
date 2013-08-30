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

		// tmp
		SetScoreText(0);

		DoCallout("INCOMING WAVE", 3);
	}

	private void SetScoreText(int score) {
		m_scoreLabel.text = "SCORE : " + score;
	}

	private void LivesUpdated(int lives) {
		m_livesLabel.text = "LIVES : " + lives;
	}
	private void SetCalloutText(string callout) {
		m_calloutLabel.text = callout;
	}
	private void ClearCalloutText() {
		SetCalloutText("");
	}

	private void DoCallout(string callout, float time = 1.0f) {
		SetCalloutText(callout);
		Invoke("ClearCalloutText", time);
	}
}
