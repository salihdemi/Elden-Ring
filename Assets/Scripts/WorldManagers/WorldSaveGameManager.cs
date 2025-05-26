using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSaveGameManager : MonoBehaviour
{
    public static WorldSaveGameManager instance;

    private void Awake()
    { if (instance == null) { instance = this; } /*else { Destroy(gameObject); } */}



    public int worldSceneIndex = 1;
    public int GetWorldSceneIndex()
    {
        return worldSceneIndex;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public IEnumerator LoadNewGame()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
        yield return null;
    }
}
