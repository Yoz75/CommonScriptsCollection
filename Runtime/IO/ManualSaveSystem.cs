using System;
using System.Collections;
using UnityEngine;

namespace CSC.IO
{
    public class ManualSaveSystem : SaveSystem
    {
		public void Save()
		{
			NotifyListeners();
		}
    }
}