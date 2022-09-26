using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class StartTimer : MonoBehaviour
{
    public Text timerText;
    public Text buttonText;
    public Text descriptionText;
    public bool timerIsRunning = false;
    public bool paused = false;
    public float workingCountdown = 1200;
    public float timeRemaining;// = 50;
    public bool lookingAway = false;
    public float awayCountdown = 20;


    //private Vibration vib;


    // Start is called before the first frame update
    void Start()
    {
    	//vib = GetComponent<Vibration>();
    	timeRemaining = workingCountdown;
    	buttonText.text = "Begin 20 Mintues";
    	descriptionText.text = "20 Minutes of work";
        updateTimer();
    }

    // Update is called once per frame
    void Update()
    {
       if (timerIsRunning) {
       		if (timeRemaining > 0){
       			timeRemaining -= Time.deltaTime;
       		}
       		else{
       			timeRemaining = 0;
       			timerIsRunning = false;
       			
       			Vibration.Vibrate(250);
       			Debug.Log("Btzzz");
       			if(lookingAway == false){
       				descriptionText.text = "Look at something 20ft away for 20 seconds";
       				buttonText.text = "Begin 20 seconds";
       			}
       			else{
       				descriptionText.text = "20 Minutes of work";
       				buttonText.text = "Begin 20 Mintues";
       			}
       			lookingAway = !lookingAway;

       		}
       		updateTimer();
       }
    }

    void updateTimer(){
    	float minutes = Mathf.FloorToInt(timeRemaining/ 60);
    	float seconds = Mathf.FloorToInt(timeRemaining % 60);

    	timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    void OnMouseDown()
    {
    	//timerText.text = "20:00";
    	if(timerIsRunning == false  && paused == false){ //First press
    		timerIsRunning = true;
    		if (lookingAway){
    			timeRemaining = awayCountdown;
    		}
    		else{
    			timeRemaining = workingCountdown;
    		}
    		
    		buttonText.text = "Pause";
    	}
    	else if(timerIsRunning){
    		paused = true;
    		timerIsRunning = false;
    		buttonText.text = "Resume";
    		descriptionText.text = "Paused";
    	}
    	else if(paused){
    		paused = false;
    		timerIsRunning= true;
    		buttonText.text = "Pause";
    		if(lookingAway){
    			descriptionText.text = "Look at something 20ft away for 20 seconds";
    		}
    		else{
    			descriptionText.text = "20 Minutes of work";
    		}
    	}
    	
    }
}
