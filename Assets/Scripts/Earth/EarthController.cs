//
// EarthController.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地球オブジェクト操作クラス
/// </summary>
public class EarthController : MonoBehaviour
{

    // 半径
    private float m_radius;

    // メッシュ
    private Mesh m_mesh;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start ()
    {
        // 半径を初期化
        m_radius = GetComponent<SphereCollider>().radius;

        // メッシュの作成
        m_mesh = GetComponent<MeshFilter>().mesh;
    }
	
	/// <summary>
    /// 更新処理
    /// </summary>
	private void Update ()
    {
    }

    #region プロパティ
    /// <summary>
    /// 半径
    /// </summary>
    public float Radius
    {
        get { return m_radius; }
    }
    /// <summary>
    /// メッシュ
    /// </summary>
    public Mesh Mesh
    {
        get { return m_mesh; }
    }
    #endregion
}
