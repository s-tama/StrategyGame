//
// StickController.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIスティック操作クラス
/// </summary>
public class StickController : UIBase
{

    // フラグ用定数
    public readonly byte ROTATE_UP = 1 << 7;
    public readonly byte ROTATE_DOWN = 1 << 6;
    public readonly byte ROTATE_RIGHT = 1 << 5;
    public readonly byte ROTATE_LEFT = 1 << 4;


    // 元の座標
    private Vector2 m_origin;

    // フラグ
    private Flag m_flag = new Flag();

   
	/// <summary>
    /// 開始処理
    /// </summary>
	private void Start ()
    {
        // 元の座標を初期化
        m_origin = GetComponent<Image>().rectTransform.position;

        // 状態を初期化
        m_currentState = new NoneStick(this);
    }
	
	/// <summary>
    /// 更新処理
    /// </summary>
	private void Update ()
    {
        // 現在の状態を実行する
        if (m_currentState != null)
        {
            m_currentState.Execute();
        }
    }

    #region プロパティ
    /// <summary>
    /// 元の座標
    /// </summary>
    public Vector2 Origin
    {
        get { return m_origin; }
    }
    /// <summary>
    /// フラグ
    /// </summary>
    public Flag Flag
    {
        get { return m_flag; }
    }
    #endregion
}
