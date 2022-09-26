using System;
using System.Collections;

internal interface ICountDown
{
    /// <summary>
    /// カウントダウン
    /// </summary>
    void CountDown(params Action[] action);
}