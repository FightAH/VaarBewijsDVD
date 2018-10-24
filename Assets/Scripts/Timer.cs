using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Image fillImg;
    float timeAmt = 2;
    float time;
    public Text timeText;

	// Use this for initialization
	void Start () {
        fillImg = this.GetComponent<Image>();
        time = timeAmt;
	}
	
	// Update is called once per frame
	void Update () {
		if(time > 0)
        {
            time -= Time.deltaTime;
            fillImg.fillAmount = time / timeAmt;
            timeText.text = "Time: " + time.ToString("F");
        }
        if (time < 0)
        {
            if (ButtonManager.ID < 24)
            {
                ButtonManager.ID = ButtonManager.ID + 1;
                time = 1;
            }
        }
	}
}
