//
// UIBase.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI基底クラス
/// </summary>
public class UIBase : MonoBehaviour
{

    // 現在の状態
    protected UIState m_currentState = null;


    /// <summary>
    /// 状態の変更
    /// </summary>
    /// <param name="nextState">次の状態</param>
    public void ChangeState(UIState nextState)
    {
        m_currentState = null;
        m_currentState = nextState;
    }
}
