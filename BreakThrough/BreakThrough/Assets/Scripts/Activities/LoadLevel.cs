using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public void loadLevel(int buildIndex)
    {
		//SceneManager.LoadScene (buildIndex);
		//LoadingSceneManager.LoadScene(buildIndex);
		LoadingScreenManager.LoadScene(buildIndex);
    }
}
