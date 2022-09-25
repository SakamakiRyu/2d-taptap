using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���̐i�s���Ǘ�����N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    public enum Scene
    {
        None = -1,
        Title,
        InGame
    }

    public Scene CurrentScene { get; private set; } = Scene.None;

    #region Unity Function
    private void Start()
    {
        ChengeScene(Scene.Title);
    }
    #endregion

    /// <summary>
    /// �V�[���̕ύX
    /// </summary>
    private void ChengeScene(Scene nextScene)
    {
        CurrentScene = nextScene;
        SceneManager.LoadScene((int)nextScene);
    }
}