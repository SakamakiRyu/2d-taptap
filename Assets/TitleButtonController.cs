using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonController : MonoBehaviour
{
    public void GameStart()
    {
        if (ServiceLocator<IGameManager>.IsValid)
        {
            ServiceLocator<IGameManager>.Instance.GameStart();
        }
    }
}
