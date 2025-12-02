
using System.IO;

namespace CSC.IO
{
    /// <summary>
    /// A static class to managing save cells
    /// </summary>
    public static class SaveCell
    {
        public static string CurrentSaveFolder = Path.Combine(GameDirectories.SavesDirectory, CurrentSaveID.ToString());
        public static int CurrentSaveID = 0;
    }
}