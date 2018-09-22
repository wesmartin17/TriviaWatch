using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	System.Timers.Timer LeTimer;
	int BoomDown = 10;
	void Start ()
	{
		//Initialize timer with 1 second intervals
		LeTimer = new System.Timers.Timer (100);
		LeTimer.Elapsed +=
			//This function decreases BoomDown every second
			(object sender, System.Timers.ElapsedEventArgs e) => BoomDown--;
	}

	void Update ()
	{
		//When BoomDown reaches 0, BOOM!
		if (BoomDown <= 0)
			Debug.Log ("Out of Time");
	}
}
