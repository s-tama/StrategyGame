//
// PolygonController.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ポリゴン操作クラス
/// </summary>
public class PolygonController
{

    #region ポリゴンの表示方法を設定
    /// <summary>
    /// ポリゴンを点で表示
    /// </summary>
    /// <param name="meshFilter">メッシュフィルター</param>
    public void AtPoints(MeshFilter meshFilter)
    {
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Points, 0);
    }

    /// <summary>
    /// ポリゴンを三角形で表示
    /// </summary>
    /// <param name="meshFilter">メッシュフィルター</param>
	public void AtTriangles(MeshFilter meshFilter)
    {
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Triangles, 0);
    }

    /// <summary>
    /// ポリゴンを四角形で表示
    /// </summary>
    /// <param name="meshFilter">メッシュフィルター</param>
	public void AtQuads(MeshFilter meshFilter)
    {
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Quads, 0);
    }

    /// <summary>
    /// ポリゴンを線で表示
    /// </summary>
    /// <param name="meshFilter">メッシュフィルター</param>
	public void AtLines(MeshFilter meshFilter)
    {
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Lines, 0);
    }

    /// <summary>
    /// ポリゴンを線分で表示
    /// </summary>
    /// <param name="meshFilter">メッシュフィルター</param>
	public void AtLineStrip(MeshFilter meshFilter)
    {
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.LineStrip, 0);
    }
    #endregion
}
