using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームの進行を管理するクラス
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
    /// シーンの変更
    /// </summary>
    private void ChengeScene(Scene nextScene)
    {
        CurrentScene = nextScene;
        SceneManager.LoadScene((int)nextScene);
    }
}