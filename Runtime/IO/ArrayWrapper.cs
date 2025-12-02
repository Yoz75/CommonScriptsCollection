using System;

namespace CSC.IO
{
    /// <summary>
    /// Helper class to wrap arrays in it (some serializers, for example <see cref="UnityEngine.JsonUtility"/>
    /// don't support raw arrays)
    /// </summary>
    /// <typeparam name="T">type of the array's element</typeparam>
    [Serializable]
    public class ArrayWrapper<T>
    {
        public T[] Values;
    }
}