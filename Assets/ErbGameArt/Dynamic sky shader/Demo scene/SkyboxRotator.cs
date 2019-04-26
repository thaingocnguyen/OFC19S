using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkyboxRotator : MonoBehaviour
{
	public float x = 0f;
	public float y = 273.65f;
	public float z = 0f;

	public Slider sunSlider;

	void Update() {
		Rotate ();
	}
	void OnEnable()
    {
		//InvokeRepeating("Rotate", 0f, 0.015f);
	}
    void Rotate()
    {
        this.transform.localEulerAngles = new Vector3(x, y, z);
    }
    void OnDisable()
    {
		//CancelInvoke();
	}

	public void OnSliderChange(float val) {
		val = sunSlider.value;
		z = val;
		//speed = val;
		//time = val;
		//Debug.Log ("CHANGE VAL: " + val);
	}
}
