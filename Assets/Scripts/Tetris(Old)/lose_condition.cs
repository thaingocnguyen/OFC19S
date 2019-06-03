using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lose_condition : MonoBehaviour {
    public List<Component> loseConds;
    public GameObject losePanel;
    private TetrisManager gameOverMain;

    private GameObject tetrisShapes;
    public Transform tetrisBlock;


    // Use this for initialization
    void Start () {
        losePanel.SetActive(false);
        loseConds = new List<Component>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject getObj = gameObject.transform.GetChild(i).gameObject;
           loseConds.Add(getObj.GetComponent<roof_obstacle>());
        }
        //Debug.Log(loseConds.Count);
        GameObject gm = GameObject.Find("GameManager");
        gameOverMain = gm.GetComponent<TetrisManager>();

        tetrisShapes = GameObject.Find("Shapes");
        

		
	}
	
	// Update is called once per frame
	void Update () {
        hitObstacle();
        if (tetrisShapes.transform.childCount > 1)
        {
            tetrisBlock = tetrisShapes.transform.GetChild(tetrisShapes.transform.childCount - 2);
            tetrisHit();
            
        }
        
	}

    void hitObstacle()
    {
        for (int i = 0; i < loseConds.Count; i++)
        {
          if (loseConds[i].GetComponent<roof_obstacle>().hitOnObstacle)
            {
                losePanel.SetActive(true);
                gameOverMain.gameOver = true;
            } 
        }
       
    }

    void tetrisHit()
    {
        if (tetrisBlock.GetComponent<tetrisLogic>().tetrisHit)
        {
            losePanel.SetActive(true);
            gameOverMain.gameOver = true;
        }
    }

    public void TimeOut()
    {
        losePanel.SetActive(true);
        gameOverMain.gameOver = true;
    }


    public void Restarted()
    {
        for (int i = 0; i < loseConds.Count; i++)
        {
            if (loseConds[i].GetComponent<roof_obstacle>().hitOnObstacle)
            {
                loseConds[i].GetComponent<roof_obstacle>().hitOnObstacle = false;
              
            }
        }

       


        losePanel.SetActive(false);
        gameOverMain.gameOver = false;
    }

    
}
