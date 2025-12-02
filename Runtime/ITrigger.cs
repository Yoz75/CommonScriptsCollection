using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CSC
{
    public interface ITrigger
    {                
        /// <summary>
        /// Add trigger's activation listener
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(UnityAction action);
    }
}