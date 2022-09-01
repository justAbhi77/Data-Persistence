using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menumanager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI highscore;

    void Start()
    {
        ScrMgr obj = ScoreManager.scrmngr.loadscore();
        highscore.text = $"Highscore of by";
        if (obj != null)
            highscore.text = $"Highscore of {obj.name} by {obj.score}";
    }

    public void startgame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quit()
    {
        Application.Quit();
    }
}