using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rndm_sowner : MonoBehaviour {

    [HideInInspector]
    public GameObject[] shapes;
    [HideInInspector]
    public GameObject roof;
    
    public Vector3 center;
    [HideInInspector]
    public Vector3 size;
    [HideInInspector]
    public tetrisLogic tL;
    [HideInInspector]
    public List<GameObject> storedShapes;

    public TetrisManager gameOverMain;

    public GameObject spwnd_shapes;
    public int shapeCount = 0;

    public Image energyBAR;

    // Use this for initialization
    void Start () {
        // spawner();
        storedShapes = new List<GameObject>();
        spawnOne();
        tL = GameObject.FindGameObjectWithTag("tetrisObj").GetComponent<tetrisLogic>();

        GameObject gm = GameObject.Find("GameManager");
        gameOverMain = gm.GetComponent<TetrisManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOverMain.gameOver)
        {
            spawner();
            
        } else
        {
            if (spwnd_shapes.transform.childCount == shapeCount)
            {
                Destroy(spwnd_shapes.transform.GetChild(spwnd_shapes.transform.childCount - 1).gameObject);
            }
        }
        EnergyLevel();
        //Debug.Log(storedShapes.Count);

    }

    void EnergyLevel()
    {
        energyBAR.fillAmount = storedShapes.Count;
        energyBAR.rectTransform.localScale = new Vector3(storedShapes.Count/1.2f, 1, 1);
        //Debug.Log(energyBAR.fillAmount);
    }

    public void spawner()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2 ), Random.Range(-size.y / 2, size.y / 2)
            , Random.Range(-size.z / 2, size.z / 2)); 
        int i = Random.Range(0, shapes.Length);

        if (tL.isMoving == false)
        {
            //Debug.Log("hit");
            GameObject newShape = (GameObject)Instantiate(shapes[i], pos, Quaternion.Euler(-128.248f, 0f, 0f));
            newShape.name = shapes[i].name;
            //Debug.Log(newShape.name);
            newShape.transform.parent = spwnd_shapes.transform;
            storedShapes.Add(newShape);
            tL = null;
            tL = storedShapes[storedShapes.Count-1].GetComponent<tetrisLogic>();
            shapeCount++;
        }
    }
    void spawnOne()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2)
           , Random.Range(-size.z / 2, size.z / 2));
        int i = Random.Range(0, shapes.Length);
        GameObject firstShape = Instantiate(shapes[i], pos, Quaternion.Euler(-128.248f, 0f, 0f));
        firstShape.transform.parent = spwnd_shapes.transform;
        storedShapes.Add(firstShape);
        shapeCount++;
        
    }

    public void Restart()
    {
        for (int i = 0; i < spwnd_shapes.transform.childCount; i++)
        {
            Destroy(spwnd_shapes.transform.GetChild(i).gameObject);
        }
        gameOverMain.gameOver = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawCube(center, size);
    }
}
