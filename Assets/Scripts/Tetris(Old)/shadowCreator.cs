using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowCreator : MonoBehaviour {
    public Vector3 center;
    public Vector3 size;
    public tetrisLogic tL;
	// Use this for initialization
	void Start () {
        createShadow();
        tL = gameObject.GetComponentInParent<tetrisLogic>();
    }
	
	// Update is called once per frame
	void Update () {

       
	}
        
    public void createShadow()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(gameObject.transform.position.x, 0f, gameObject.transform.position.z);
        cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        MeshRenderer cubeRenderer = cube.GetComponent<MeshRenderer>();

        Material newMaterial = new Material(Shader.Find("Standard"));

        newMaterial.color = new Color(1,0,0,0.3f);
        cubeRenderer.material = newMaterial;
    }
   
}
