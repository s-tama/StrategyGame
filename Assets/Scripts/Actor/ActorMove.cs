//
// ActorMove.cs
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アクターの移動状態クラス
/// </summary>
public class ActorMove : ActorState
{
    Vector3 q;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="actor">アクター</param>
    public ActorMove(Actor actor):
        base(actor)
    {
    }

    /// <summary>
    /// 実行
    /// </summary>
    public override void Execute()
    {
        // 上下入力
        float vertical = Input.GetAxis("Vertical");
        // 左右入力
        float horizontal = Input.GetAxis("Horizontal");

        // 左右回転
        //m_actor.transform.Rotate(new Vector3(0, horizontal * 3f, 0), Space.Self);
        // 前後移動
        m_actor.transform.position += vertical * m_actor.transform.forward * 3 * Time.deltaTime;
    }
}
