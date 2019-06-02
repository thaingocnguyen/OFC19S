using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selector : MonoBehaviour
{
    private Renderer renderer;

    // Default colour of selector
    Color defaultColor = new Color32(255, 0, 0, 60);
    // Colour that is displayed when selector is hovered over 
    Color hoverColor = new Color32(69, 255, 0, 60);

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnMouseDown() {
    	SceneManager.LoadScene("block_scene");
    }

    void OnMouseEnter()
    { 
        renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color = defaultColor;
    }

}
