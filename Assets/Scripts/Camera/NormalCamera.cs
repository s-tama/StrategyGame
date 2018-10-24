//
// CameraCOntroler.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 「通常」状態
/// </summary>
public class NormalCamera : CameraState
{

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="actor">アクター</param>
    public NormalCamera(CameraController camera):
        base(camera)
    {
        m_camera = camera;
    }

    /// <summary>
    /// 実行
    /// </summary>
    public override void Execute()
    {
        // スティック
        StickController stick = m_camera.Mediator.Stick;

        // フラグ
        bool isUp = stick.Flag.Check(stick.ROTATE_UP);
        bool isDown = stick.Flag.Check(stick.ROTATE_DOWN);
        bool isRight = stick.Flag.Check(stick.ROTATE_RIGHT);
        bool isLeft = stick.Flag.Check(stick.ROTATE_LEFT);

        // 移動
        if (isRight)
        {
            m_camera.transform.RotateAround(
                    m_camera.Target.position,
                    Vector3.up,
                    m_camera.Speed * Time.deltaTime
                );
        }
        if (isLeft)
        {
            m_camera.transform.RotateAround(
                    m_camera.Target.position,
                    Vector3.up,
                    -m_camera.Speed * Time.deltaTime
                );
        }
        if (isUp)
        {
            m_camera.transform.RotateAround(
                    m_camera.Target.position,
                    m_camera.transform.right,
                    m_camera.Speed * Time.deltaTime
                );
        }
        if (isDown)
        {
            m_camera.transform.RotateAround(
                    m_camera.Target.position,
                    m_camera.transform.right,
                    -m_camera.Speed * Time.deltaTime
                );
        }
    }
}
