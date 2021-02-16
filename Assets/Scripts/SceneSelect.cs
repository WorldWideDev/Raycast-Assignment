using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSelect : MonoBehaviour {

	public void LoadScene(int scene)
    {
        if(scene != 3)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            Application.Quit();
        }
    }
}
