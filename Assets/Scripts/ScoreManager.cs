using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scrmngr;
    [SerializeField]
    string path;
    public ScrMgr scoremgr;
    private void Awake()
    {
        if (scrmngr != null){
            Destroy(gameObject);
            return;
        }
        scrmngr = this;
        DontDestroyOnLoad(gameObject);
        path = Application.persistentDataPath + "/savedata.json";
    }

    public void savescore(int score,string name)
    {
        if (scoremgr != null)
            if (scoremgr.score > score)
                return;
        ScrMgr data = new ScrMgr();
        data.score = score;
        data.name = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
        scoremgr = data;
    }
    public ScrMgr loadscore()
    {
        if (scoremgr != null)
            return scoremgr;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            scoremgr = JsonUtility.FromJson<ScrMgr>(json);
        }
        return scoremgr;
    }
}

public class ScrMgr
{
    public int score;
    public string name;
}