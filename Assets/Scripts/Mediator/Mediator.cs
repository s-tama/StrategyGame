//
// Mediator.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクト仲介役クラス
/// </summary>
public class Mediator : MonoBehaviour
{

    // 兵士への参照
    [SerializeField]
    private SoldierController m_soldier = null;
    // 地球への参照
    [SerializeField]
    private EarthController m_earth = null;
    // スティックへの参照
    [SerializeField]
    private StickController m_stick = null;


    #region プロパティ
    /// <summary>
    /// 兵士
    /// </summary>
    public SoldierController Soldier
    {
        set { m_soldier = value; }
        get { return m_soldier; }
    }
    /// <summary>
    /// 地球
    /// </summary>
    public EarthController Earth
    {
        set { m_earth = value; }
        get { return m_earth; }
    }
    /// <summary>
    /// スティック
    /// </summary>
    public StickController Stick
    {
        get { return m_stick; }
    }
    #endregion
}
