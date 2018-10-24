//
// ActorState.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アクターの状態クラス
/// </summary>
public abstract class ActorState
{

    // アクターオブジェクト
    protected Actor m_actor;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="actor">アクター</param>
    public ActorState(Actor actor)
    {
        m_actor = actor;
    }

    /// <summary>
    /// 実行
    /// </summary>
    public abstract void Execute();
}
