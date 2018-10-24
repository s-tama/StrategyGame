//
// Actor.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 行動キャラ基底クラス
/// </summary>
public class Actor : MonoBehaviour
{

    // 現在の状態
    protected ActorState m_currentState = null;


    /// <summary>
    /// 状態の変更
    /// </summary>
    /// <param name="nextState">次の状態</param>
    public void ChangeState(ActorState nextState)
    {
        m_currentState = null;
        m_currentState = nextState;
    }
}
