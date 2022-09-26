using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���̐i�s���Ǘ�����N���X
/// </summary>
public class GameManager : MonoBehaviour, IGameManager
{
    public enum Scene
    {
        None = -1,
        Title,
        InGame
    }

    // �V�[���̏����Ǘ�����N���X�Ȃ̂ŁA�V���O���g�������Ă���
    public static GameManager Instance { get; private set; } = null;

    // ���݂̃V�[��
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

    #region private Function
    /// <summary>
    /// �V�[���̕ύX
    /// </summary>
    private void ChengeScene(Scene nextScene)
    {
        CurrentScene = nextScene;

        SceneManager.LoadScene((int)nextScene);

        OnLoaded();
    }

    /// <summary>
    /// ���[�h���ꂽ��ɍs����������
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
    #endregion

    /// <summary>
    /// �Q�[���X�^�[�g
    /// </summary>
    void IGameManager.LoadToInGame()
    {
        ChengeScene(Scene.InGame);
    }
}