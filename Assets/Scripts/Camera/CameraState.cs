//
// CameraState.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの状態クラス
/// </summary>
public abstract class CameraState
{

    // カメラオブジェクト
    protected CameraController m_camera;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="actor">アクター</param>
    public CameraState(CameraController camera)
    {
        m_camera = camera;
    }

    /// <summary>
    /// 実行
    /// </summary>
    public abstract void Execute();
}
