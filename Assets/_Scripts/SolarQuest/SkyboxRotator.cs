using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkyboxRotator : MonoBehaviour
{
	public float x = 0f;
	public float y = 273.65f;
    public float z = 0f;

	public Slider sunSlider;

    private void Start()
    {
        sunSlider.onValueChanged.AddListener(delegate { OnSliderChange(); });
    }

	public void OnSliderChange() {
        this.transform.localEulerAngles = new Vector3(x, y, sunSlider.value);
    }
}
