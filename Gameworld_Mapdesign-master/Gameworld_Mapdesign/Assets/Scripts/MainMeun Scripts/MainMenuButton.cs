using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButton : MonoBehaviour {

    public GameObject  mainMenu, loadMenu;

	public void NewGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void LoadGame()
    {
        mainMenu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        loadMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
