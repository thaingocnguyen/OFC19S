﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class InterfaceManager : MonoBehaviour
    {
        public bool mouseOverUIElement;

        private static InterfaceManager instance = null;

        private void Awake()
        {
            instance = this;
        }

        public static InterfaceManager GetInstance()
        {
            return instance;
        }

        public void MouseEnter()
        {
            mouseOverUIElement = true;
        }

        public void MouseExit()
        {
            mouseOverUIElement = false;
        }
    }

}
