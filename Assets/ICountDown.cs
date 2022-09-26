using System;
using System.Collections;

internal interface ICountDown
{
    IEnumerator RequestCountDown(Action action = null);
}