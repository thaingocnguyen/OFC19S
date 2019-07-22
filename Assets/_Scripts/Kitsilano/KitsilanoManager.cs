using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsilanoScene
{
    public class KitsilanoManager : MonoBehaviour
    {


        #region Singleton
        private static KitsilanoManager instance = null;
        public static KitsilanoManager GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            

        }


    }

}
