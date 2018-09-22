using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class QuestionHandler : MonoBehaviour {

	private static string gameDataFileName = "testdata.json";

	private Question[] questions;

	private int currentQ = 0;
	public static int MAX_QUESTIONS = 19;

	public QuestionHandler(){		
		questions = getQuestionsFromJSON ();
		Debug.Log (questions.ToString());
	}

	public Question getNextQuestion(){
		if (currentQ < MAX_QUESTIONS) {
			currentQ++;
			return questions [currentQ - 1];
		} else {
			SceneManager.LoadScene (2);
			return questions[19];
		}
	}

	public bool checkAnswer(int selected){
		return selected == questions [currentQ].getCorrectAnswer ();
	}

	private static Question[] getQuestionsFromJSON(){


		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
		if(File.Exists(filePath))
		{
			// Read the json from the file into a string
			string dataAsJson = File.ReadAllText(filePath); 
			// Pass the json to JsonUtility, and tell it to create a GameData object from it
				Question[] questions = JsonHelper.FromJson<Question>(dataAsJson);
			Debug.Log (questions.Length);
			return questions;
		}
		else
		{
			Debug.LogError("Cannot load game data!");
			return null;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadJSON(){
		
	}
}
