using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonEventHandler : MonoBehaviour {

	Sprite defaultImage;
	public Sprite correctImage;
	public Sprite wrongImage;

	public bool isCorrectAnswer;

	// Use this for initialization
	void Start () {
			defaultImage = GetComponent<Button> ().image.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setIsCorrectAnswer(bool isCorrectAnswer){
		this.isCorrectAnswer = isCorrectAnswer;
	}

	public void OnClick(){
		if (isCorrectAnswer) {
			StartCoroutine (flashColors (correctImage));
		} else {
			StartCoroutine (flashColors (wrongImage));
		}
		GameController.gameController.timerBreaker = true;
		StartCoroutine (nextQuestion ());
	}

	IEnumerator flashColors(Sprite sprite){
		GetComponent<Button> ().image.sprite = sprite;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Button> ().image.sprite = defaultImage;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Button> ().image.sprite = sprite;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Button> ().image.sprite = defaultImage;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Button> ().image.sprite = sprite;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Button> ().image.sprite = defaultImage;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Button> ().image.sprite = sprite;
	}

	IEnumerator nextQuestion(){
		yield return new WaitForSeconds (1.2f);
		GameController.gameController.loadQuestion ();
	}

	public void onWrongAnswer(){

		StartCoroutine (flashColors (wrongImage));

	}

	public void setDefaultImage(){
		GetComponent<Button> ().image.sprite = defaultImage;
	}

}
