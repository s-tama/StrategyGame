//
// Flag.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フラグクラス
/// </summary>
public class Flag
{

    // フラグ用変数
    byte m_flag = 0x0000;


    /// <summary>
    /// フラグのチェック
    /// </summary>
    /// <param name="flag"></param>
    /// <returns></returns>
    public bool Check(byte flag)
    {
        return ((m_flag & flag) != 0x0000)? true:false;
    }

    /// <summary>
    /// フラグのオン
    /// </summary>
    public void On(byte flag)
    {
        m_flag |= flag;
    }

    /// <summary>
    /// フラグのオフ
    /// </summary>
    /// <param name="flag"></param>
    public void Off(byte flag)
    {
        m_flag &= (byte)~flag;
    }

    /// <summary>
    /// 全フラグのオフ
    /// </summary>
    public void OffAll()
    {
        m_flag &= 0x0000;
    }
}
