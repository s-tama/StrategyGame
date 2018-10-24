//
// CameraController.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラ操作クラス
/// </summary>
public class CameraController : MonoBehaviour
{

    // ターゲットの変換情報
    [SerializeField]
    private Transform m_target = null;

    // 回転の速さ
    [SerializeField]
    private float m_rotateSpeed = 20;

    // 現在の状態
    private CameraState m_currentState;

    // メディエーター
    private Mediator m_mediator;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();

        // 状態の初期化
        m_currentState = new NormalCamera(this);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        // 現在の状態を実行
        if (m_currentState != null)
        {
            m_currentState.Execute();
        }
    }

    /// <summary>
    /// 状態の変更
    /// </summary>
    /// <param name="nextState">次の状態</param>
    public void ChangeState(CameraState nextState)
    {
        m_currentState = null;
        m_currentState = nextState;
    }

    #region プロパティ
    /// <summary>
    /// メディエーター
    /// </summary>
    public Mediator Mediator
    {
        get { return m_mediator; }
    }
    /// <summary>
    /// ターゲットの変換情報
    /// </summary>
    public Transform Target
    {
        get { return m_target; }
    }
    /// <summary>
    /// 回転速度
    /// </summary>
    public float Speed
    {
        get { return m_rotateSpeed; }
    }
    #endregion
}
