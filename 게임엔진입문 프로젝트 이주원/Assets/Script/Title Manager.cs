using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject helpPenal;

    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene_Door1");
    }

    public void OpenHelp()
    {
        helpPenal.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPenal.SetActive(false);
    }







}
