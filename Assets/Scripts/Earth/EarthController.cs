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

    List<Vector3> m_vertList = new List<Vector3>();


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start ()
    {
        // 半径を初期化
        m_radius = GetComponent<SphereCollider>().radius;

        // メッシュの作成
        m_mesh = GetComponent<MeshFilter>().mesh;

        // オブジェクトを点で表示
        PolygonController p = new PolygonController();
        p.AtTriangles(GetComponent<MeshFilter>());

        for (int i = 0; i < m_mesh.vertices.Length; i++)
        {
            m_vertList.Add(m_mesh.vertices[i]);
        }
        for (int i = 0; i < m_vertList.Count; i++)
        {
            m_vertList[i] += m_mesh.normals[i].normalized * 1;
        }
    }
	
	/// <summary>
    /// 更新処理
    /// </summary>
	private void Update ()
    {
        //m_mesh.SetVertices(m_vertList);
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
