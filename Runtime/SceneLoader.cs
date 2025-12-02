using System.Collections;
using UnityEngine;

namespace CSC
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private float Delay;

        public void Load(string name)
        {
            StartCoroutine(LoadCoroutine(name));
        }

        private IEnumerator LoadCoroutine(string name)
        {
            yield return new WaitForSeconds(Delay);
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }
    }
}