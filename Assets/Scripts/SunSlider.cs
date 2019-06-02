using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunSlider : MonoBehaviour
{
	public float time;
	public TimeSpan currenttime;
	public Transform SunTransform;
	public Light Sun;
	public Text timetext;
	public int days;
	public float intensity;
	public Color fogday = Color.grey;
	public Color fognight = Color.black;

	public float speed;
	public Slider sunSlider;

	void Update()
	{
		Changetime();

	}
	public void Changetime()
	{
		//time+= Time.deltaTime * speed;
		if(time > 86400) {
			days += 1;
			time =0;
		}
		currenttime = TimeSpan.FromSeconds (time);
		string[] temptime = currenttime.ToString().Split(":"[0]);
		timetext.text = temptime[0] + ":" + temptime [1];

		SunTransform.rotation = Quaternion.Euler(new Vector3((time-21600/86400*360),0,0));
		if(time < 43200)
			intensity =  (43200 - time) / 43200;
		else
			intensity =  ((43200 - time) / 43200*-1);

		RenderSettings.fogColor = Color.Lerp(fognight, fogday, intensity * intensity);
		Sun.intensity = intensity;
	}

	public void OnSliderChange(float val) {
		val = sunSlider.value;
		//speed = val;
		time = val;
		//Debug.Log ("CHANGE VAL: " + val);
	}
}
