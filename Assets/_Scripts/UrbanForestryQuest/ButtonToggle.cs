using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor
{
    public class ButtonToggle : MonoBehaviour
    {
        private Button button;
        private bool toggleOn;
        // Start is called before the first frame update
        void Start()
        {
            toggleOn = false;
            button = GetComponent<Button>();
        }

        public bool On
        {
            get { return toggleOn; }
            set { toggleOn = value; }
        }

        private void Update()
        {
            ToggleButton();
        }

        private void ToggleButton()
        {
            if(toggleOn)
            {
                ColorBlock cb = button.colors;
                cb.normalColor = Color.green; 
                cb.selectedColor = Color.green;
                button.colors = cb;
            }
            else
            {
                ColorBlock cb = button.colors;
                cb.normalColor = Color.white;
                cb.selectedColor = Color.white;
                button.colors = cb;
            }
        }
    }
}

