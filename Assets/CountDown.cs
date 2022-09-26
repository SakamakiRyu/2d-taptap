using System;
using System.Collections;
using UnityEngine;

public class CountDown : MonoBehaviour, ICountDown
{
    [SerializeField]
    private UnityEngine.UI.Text _countDownText;

    [SerializeField]
    private float _countDownTime;

    private void Awake()
    {
        _countDownText.text = "";
    }

    IEnumerator ICountDown.RequestCountDown(Action action)
    {
        var timer = _countDownTime;
        yield return null;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            int time = (int)timer;
            _countDownText.text = time.ToString();
            yield return null;
        }

        _countDownText.enabled = false;
        action();
    }
}
