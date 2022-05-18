using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// �������� ������ �����
    /// </summary>
    /// <param name="scene"></param>
    public void LoadSceneByNumber(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// �������� ������ �����
    /// </summary>
    public void ThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// �������� ��������� �����
    /// </summary>
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
