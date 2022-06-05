using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Загрузка нужной сцены
    /// </summary>
    /// <param name="scene"></param>
    public void LoadSceneByNumber(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Загрузка данной сцены
    /// </summary>
    public void ThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Загрузка следующей сцены
    /// </summary>
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSaveBase()
    {
        SceneManager.LoadScene(Base.Level + 1);
    }
}
