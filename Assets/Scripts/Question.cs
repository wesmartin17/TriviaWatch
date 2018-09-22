using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

[System.Serializable]
public class Question{

	[SerializeField]
	private string question = "Default Text here";
	[SerializeField]
	private string[] answers = { "Default A answer", "Default B answer", "Default C answer", "Default D answer" };
	[SerializeField]
	private int correctAnswer = 0;

	public Question (string question, string[] answers, int correctAnswer){
		this.question = question;
		this.answers = answers;
		this.correctAnswer = correctAnswer;
	}


	public string getQuestion(){
		return question;
	}

	public int getCorrectAnswer(){
		return correctAnswer;
	}

	public string[] getAnswers(){
		return answers;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
