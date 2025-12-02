
using UnityEngine;

namespace CSC.IO
{
    /// <summary>
    /// Helper class to create unique (and mostly human-readable) names for game object save files
    /// </summary>
    public static class NameCreator
    {
        /// <summary>
        /// Get unique name for an object
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns>unique name</returns>
        public static string CreateUniqueName(GameObject gameObject)
        {
            return gameObject.scene.name + gameObject.name + gameObject.GetInstanceID();
        }
    }
}