using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームの進行を管理するクラス
/// </summary>
public class GameManager : MonoBehaviour, IGameManager
{
    // シーンの情報を管理するクラスなので、シングルトン化している
    public static GameManager Instance { get; private set; } = null;

    public enum Scene
    {
        None = -1,
        Title,
        InGame
    }

    public Scene CurrentScene { get; private set; } = Scene.None;

    #region Unity Function
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        ChengeScene(Scene.Title);
    }

    private void OnEnable()
    {
        if (!ServiceLocator<IGameManager>.IsValid)
        {
            ServiceLocator<IGameManager>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<IGameManager>.IsValid)
        {
            ServiceLocator<IGameManager>.UnRegist(this);
        }
    }
    #endregion

    /// <summary>
    /// シーンの変更
    /// </summary>
    private void ChengeScene(Scene nextScene)
    {
        CurrentScene = nextScene;

        SceneManager.LoadScene((int)nextScene);

        OnLoaded();
    }

    /// <summary>
    /// ロードされた後に行いたい処理
    /// </summary>
    private void OnLoaded()
    {
        switch (CurrentScene)
        {
            case Scene.None:
                break;
            case Scene.Title:
                break;
            case Scene.InGame:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ゲームスタート
    /// </summary>
    public void GoToInGame()
    {
        ChengeScene(Scene.InGame);
    }
}