using System;
using System.Collections;

public interface ICountDown
{
    /// <summary>
    /// カウントダウン
    /// </summary>
    void CountDown(params Action[] action);
}