using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ExtraTeypsForBuildingGame
{

    [Serializable]
    public struct XData
    {
        public float money;
        public float energy;
        public float water;
        public float food;
        public float person;

    }

    [Serializable]
    public struct YData
    {
       public XData value;
       public XData maxValue;
    }


}
