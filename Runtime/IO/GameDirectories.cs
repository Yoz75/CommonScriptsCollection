using System.IO;
using UnityEngine;

namespace CSC.IO
{
    /// <summary>
    /// Game Directories for saves etc.
    /// </summary>
    public static class GameDirectories
    {
        private static string GameDataDirectory_ = Application.persistentDataPath;

        private const string DefaultSavesFolderName = "Saves";
        private static string SavesDirectory_ = Path.Combine(Application.persistentDataPath, DefaultSavesFolderName);

        /// <summary>
        /// Root directory for all other game gata. Default value is <see cref="Application.persistentDataPath"/>
        /// </summary>
        public static string GameDataDirectory
        {
            get
            {
                if(!Directory.Exists(GameDataDirectory_))
                {
                    Directory.CreateDirectory(GameDataDirectory_);
                }

                return GameDataDirectory_;
            }

            set
            {
                GameDataDirectory_ = value;
            }
        }

        /// <summary>
        /// Root directory for saves. Default value is [<see cref="Application.persistentDataPath"/>]/Saves.
        /// You can set this property to any other directory (even not inside <see cref="GameDataDirectory"/>
        /// </summary>
        public static string SavesDirectory
        {
            get
            {
                if(!Directory.Exists(SavesDirectory_))
                    Directory.CreateDirectory(SavesDirectory_);

                return SavesDirectory_;
            }

            set
            {
                SavesDirectory_ = value; 
            }
        } 
    }
}