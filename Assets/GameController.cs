using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private QuestionHandler questionHandler;

	public Text questionText;

	public Button buttonA;
	public Button buttonB;
	public Button buttonC;
	public Button buttonD;

	public Text timer;
	public bool timerBreaker = false;

	private Sprite[] defaultSprites;
	private Button[] buttons;

	public static GameController gameController = null;


	// Use this for initialization
	void Start () {
		gameController = this;
		questionHandler = new QuestionHandler ();
		buttons = new Button[]{ buttonA, buttonB, buttonC, buttonD };
		defaultSprites = new Sprite[4];
		for (int i = 0; i < 4; i++) {

			defaultSprites [i] = buttons [i].image.sprite;

		}
		loadQuestion ();
	}



	public void loadQuestion(){

	
		Debug.Log ("LOADIGN QUESTION");

		for (int i = 0; i < 4; i++) {
			buttons [i].enabled = false;
			buttons [i].enabled = true;
			buttons [i].image.sprite = defaultSprites [i];
		}
		Question q = questionHandler.getNextQuestion ();
		questionText.text = q.getQuestion ().ToUpper();
		for (int i = 0; i < 4; i++) {
			if (q.getCorrectAnswer() == i)
				buttons [i].GetComponentInChildren<ButtonEventHandler> ().setIsCorrectAnswer (true);
			else
				buttons [i].GetComponentInChildren<ButtonEventHandler> ().setIsCorrectAnswer (false);
			buttons [i].GetComponentInChildren<Text> ().text = q.getAnswers () [i].ToUpper();
			Debug.Log ("Button " + i + " is set");
		}
		timerBreaker = false;
		StartCoroutine(countdown (10));

	}

	public IEnumerator countdown(int seconds){
		
		for (int i = 0; i < 11; i++) {
			if (timerBreaker)
				yield break;
			Debug.Log ("countind down");
			timer.text = "" + seconds;
			seconds--;
			yield return new WaitForSeconds (1f);
		}
		loadQuestion ();
		yield break;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
