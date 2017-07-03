using System;
using UnityEngine;

    public class RoutineRunner : MonoBehaviour
    {
        static RoutineRunner mInstance;

        public static RoutineRunner Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = FindObjectOfType<RoutineRunner>();
                }
                return mInstance;
            }
        }

        void Awake()
        {
            mInstance = this;
        }
       
    }