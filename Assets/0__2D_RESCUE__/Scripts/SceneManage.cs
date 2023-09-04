using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage: MonoBehaviour
{
    public void ToLoding()
    {
        SceneManager.LoadScene("1__LODING__");
    }

    public void ToManual()
    {
        SceneManager.LoadScene("2__MENUAL__");
    }

    public void Forest()
    {
        SceneManager.LoadScene("3__FOREST__");
    }

    public void Ocean()
    {
        SceneManager.LoadScene("4__OCEAN__");
    }

    public void Space()
    {
        SceneManager.LoadScene("5__SPACE__");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
