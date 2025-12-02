
using System.IO;
using UnityEngine;

namespace CSC.IO
{
    /// <summary>
    /// Something that can be loaded **and** saved. You can have many SaveLoadables on one object!
    /// </summary>
    public abstract class SaveLoadable : MonoBehaviour
    {
        [SerializeField] private LoadSystem LoadSystem;
        [SerializeField] private SaveSystem SaveSystem;

        /// <summary>
        /// Save file extension. Default is .sav
        /// </summary>
        protected string FileExtension = ".sav";

        /// <summary>
        /// Path of save file inside current save directory 
        /// (e.g if InnerPath == "MySaves/SpecialSaves, whole path will be:
        /// [save directory]/MySaves/SpecialSaves/[saveFile]
        /// </summary>
        protected string InnerPath = "";

        protected void Awake()
        {
            if(LoadSystem == null)
            {
                LoadSystem = 
                    GameObject.FindGameObjectWithTag(LoadSystem.StandardLoadSystemTag).GetComponent<LoadSystem>();
            }
            if(SaveSystem == null)
            {
                SaveSystem = GameObject.FindGameObjectWithTag(SaveSystem.StandardSaveSystemTag).GetComponent<SaveSystem>();
            }
            LoadSystem.LoadRequired += Load;
            SaveSystem.SaveRequired += Save;
        }

        /// <summary>
        /// Load component from the save file. 
        /// If the save file does not exist, it will be created and method will not be called.
        /// </summary>
        /// <param name="fileContent">content of save file</param>
        protected abstract void OnLoad(string fileContent);

        /// <summary>
        /// Serialize component to a string
        /// </summary>
        /// <returns>serialized component</returns>
        protected abstract string OnSave();

        private void Load()
        {
            string innerPath = Path.Combine(SaveCell.CurrentSaveFolder, InnerPath);
            string filePath =
                Path.Combine(SaveCell.CurrentSaveFolder,
                InnerPath,
                NameCreator.CreateUniqueName(gameObject) + FileExtension);

            if(!Directory.Exists(innerPath))
            {
                Directory.CreateDirectory(innerPath);
            }

            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                // Return because we created file just now and currently it's invalid
                return;
            }

            OnLoad(File.ReadAllText(filePath));
        }

        private void Save()
        {
            string innerPath = Path.Combine(SaveCell.CurrentSaveFolder, InnerPath);
            string filePath =
                Path.Combine(SaveCell.CurrentSaveFolder,
                InnerPath,
                NameCreator.CreateUniqueName(gameObject) + FileExtension);

            if(!Directory.Exists(innerPath))
            {
                Directory.CreateDirectory(innerPath);
            }

            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            File.ReadAllText(OnSave());
        }
    }
}