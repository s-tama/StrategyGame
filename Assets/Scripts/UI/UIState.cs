//
// UIState.cs
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI状態クラス
/// </summary>
public abstract class UIState
{

    // UIベース
    protected UIBase m_uiBase;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="uiBase">UIベース</param>
    public UIState(UIBase uiBase)
    {
        m_uiBase = uiBase;
    }

    /// <summary>
    /// 実行
    /// </summary>
    public abstract void Execute();
}
