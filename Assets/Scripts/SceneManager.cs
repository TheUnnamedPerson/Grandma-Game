using UnityEngine;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour
{
    
    //public string[] SceneCodes;

    public static SceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void LoadScene(string sceneCode)
    {
        Debug.Log($"Attempting to load scene with code: {sceneCode}");
        try
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneCode);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error loading scene with code '{sceneCode}': {ex.Message}");
        }
    }

}
