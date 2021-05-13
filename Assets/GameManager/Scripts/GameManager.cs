using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Character;





public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED,
        DEAD,
        RETRY
    }

    #region Level System

    public static string firstLevel = "Level1";

    [SerializeField]public static string currentLevel = string.Empty;

    public string CurrentLevel
    {
        get { return currentLevel; }
    }


    

    #endregion

    public GameObject[] SystemPrefabs;
    public Events.EventGameState OnGameStateChanged;
    

    List<GameObject> _instancedSystemPrefabs;
    List<AsyncOperation> _loadOperations;
    GameState _currentGameState = GameState.PREGAME;

    

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        private set { _currentGameState = value; }
    }

    private void Start()
    {

        DontDestroyOnLoad(gameObject);


        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();

        InstantiateSystemPrefabs();

        UIManager.Instance.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
        PlayerScript.OnDie += HandleOnDie;
        
        


    }
    void HandleOnDie()
    {
        UpdateState(GameState.DEAD);
        
    }

    void HandleMainMenuFadeComplete(bool fadeOut)
    {
        if (!fadeOut)
        {
            UnLoadLevel(currentLevel);
        }
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            if(_loadOperations.Count == 0)
            {
                UpdateState(GameState.RUNNING);
            }
            
        }
        Debug.Log("Load Complete!");
    }
    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload Complete!");
    }

    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;

            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;

            case GameState.PAUSED:

                Time.timeScale = 0.0f;
                break;

            case GameState.DEAD:
                
                Time.timeScale = 1.0f;
                break;

            case GameState.RETRY:
                Time.timeScale = 1.0f;
                break;

            default:
                break;
        }

        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
        Debug.Log("[GameManager] GameState changed from " + previousGameState + " to " + _currentGameState);
        
        
    }

    void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for(int i=0; i<SystemPrefabs.Length; i++)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao =  SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if(ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level" + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        
        currentLevel = levelName;
    }
    public void UnLoadLevel(string levelName)
    {
        AsyncOperation ao =  SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + levelName);
            return;
        }

        ao.completed += OnUnloadOperationComplete;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        for (int i = 0; i < _instancedSystemPrefabs.Count ; i++)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }

    public void StartGame()
    {
        LoadLevel("Level1");
    }

    public void TogglePause()
    {
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }
    public void LoadMenu()
    {
        UpdateState(GameState.PREGAME);
    }
    public void Retry()
    {
        UpdateState(GameState.RETRY);
        UnLoadLevel(currentLevel);
        LoadLevel(currentLevel);

    }

    public void QuitGame()
    {
        //AUTOSAVE 
        //CLEANUPS

        Application.Quit();
        Debug.Log("QUIT!!");
    }
}
