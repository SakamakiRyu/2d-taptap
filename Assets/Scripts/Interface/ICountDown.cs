using System;
using System.Collections;

internal interface ICountDown
{
    /// <summary>
    /// カウントダウンのリクエスト
    /// </summary>
    IEnumerator RequestCountDown(params Action[] action);
}