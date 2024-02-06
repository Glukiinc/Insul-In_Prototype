using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    //The order of the scenes in this enum MUST match to the order they appear
    //in the build setting!
    public enum Scenes
    {
        STARTMENU,
        INSULINBALLTEST,
        INSULINBALLTUTORIAL 
    }

    public Scenes currentScene { get; private set; }

    //GameSceneManager is a singleton and handles scene changes
    public static GameSceneManager Instance { get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentScene = Scenes.STARTMENU;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(Scenes scene)
    {
        currentScene = scene;
        SceneManager.LoadScene((int)scene);
    }

    public void StartGame()
    {
        LoadScene(Scenes.INSULINBALLTEST);
    }

    public void EnterTutorial()
    {
        LoadScene(Scenes.INSULINBALLTUTORIAL);
    }

    public void ReturnToStartMenu()
    {
        LoadScene(Scenes.STARTMENU);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting!");
    }
}
