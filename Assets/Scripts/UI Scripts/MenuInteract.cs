using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInteract : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene("Lvl1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
