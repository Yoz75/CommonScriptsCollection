using System;
using UnityEngine;

namespace CSC
{
    public abstract class Props : ScriptableObject, ICloneable
    {
        /// <summary>
        /// Clone self
        /// </summary>
        /// <returns>self clone as object</returns>
        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}