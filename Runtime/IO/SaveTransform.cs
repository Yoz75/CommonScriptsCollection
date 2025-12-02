
using System.IO;
using UnityEngine;

namespace CSC.IO
{
    /// <summary>
    /// Position, rotation and scale of unity transform.
    /// </summary>
    public struct SavableTransform
    {
        public Vector3 Position, Rotation, Scale;
    }

    public class SaveTransform : SaveLoadable
    {
        private static string TransformsFolder;

        private void Start()
        {
            TransformsFolder = Path.Combine(SaveCell.CurrentSaveFolder, "Transforms");
        }

        protected override void OnLoad(string fileContent)
        {
            SavableTransform transform = JsonUtility.FromJson<SavableTransform>(fileContent);

            gameObject.transform.position = transform.Position;
            var rotation = gameObject.transform.rotation;
            rotation.eulerAngles = transform.Rotation;
            gameObject.transform.rotation = rotation;
            gameObject.transform.localScale = transform.Scale;
        }

        protected override string OnSave()
        {
            SavableTransform transform = new SavableTransform();
            transform.Position = gameObject.transform.position;
            transform.Rotation = gameObject.transform.rotation.eulerAngles;
            transform.Scale = gameObject.transform.localScale;

            return JsonUtility.ToJson(transform);
        }
    }
}