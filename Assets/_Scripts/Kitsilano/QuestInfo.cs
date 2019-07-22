using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace KitsilanoScene
{
    public class QuestInfo : MonoBehaviour
    {
        [SerializeField] int questNumber;
        [SerializeField] TextMeshProUGUI highScoreText;

        KitsilanoManager manager;

        // Start is called before the first frame update
        void Start()
        {
            //LoadInfo();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //void LoadInfo()
        //{
        //    manager = KitsilanoManager.GetInstance();
        //    switch (questNumber)
        //    {
        //        case 0:
        //            highScoreText.text = manager.solarQuestHighScore.ToString();
        //            break;
        //        case 1:
        //            highScoreText.text = manager.ufQuestHighScore.ToString();
        //            break;
        //        default:
        //            Debug.Log("Invalid quest number!");
        //            break;
        //    }
        //}
    }

}
