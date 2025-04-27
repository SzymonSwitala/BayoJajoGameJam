using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    enum EscapeButtonAction
    {
        quitGame, backToMenu
    }

    [SerializeField] EscapeButtonAction escapeButtonAction;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapeButtonAction == EscapeButtonAction.quitGame) QuitGame();
            else LoadScene(0);
        }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
