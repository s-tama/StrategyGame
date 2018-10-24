//
// Soldier.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 兵士操作クラス
/// </summary>
public class SoldierController : Actor
{

    // アンカーポイント
    [SerializeField]
    private Transform m_anchorPoint;

    // メディエーター
    private Mediator m_mediator;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update ()
    {
        // 上下入力
        float vertical = Input.GetAxis("Vertical");
        // 左右入力
        float horizontal = Input.GetAxis("Horizontal");

        // 左右回転
        Quaternion q = Quaternion.Euler(horizontal * this.transform.up);
        this.transform.rotation *= q;
        // 前後移動
        this.transform.position += vertical * this.transform.forward * 3 * Time.deltaTime;

        // レイ
        Ray ray = new Ray(m_anchorPoint.position, -this.transform.up);
        // ヒットしたオブジェクトの情報
        RaycastHit hit;
        // レイを真下に飛ばす地形の法線情報を調べる
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // ヒットしたオブジェクトの法線に上方向ベクトルを設定
            Vector3 forwardVector = Vector3.ProjectOnPlane(this.transform.forward, hit.normal);
            this.transform.rotation = Quaternion.LookRotation(forwardVector, hit.normal);

            if (hit.distance > 0.05f)
            {
                this.transform.position -= this.transform.up / 100;
            }
        }
    }

    /// <summary>
    /// 球面座標を取得
    /// </summary>
    /// <param name="angle1"></param>
    /// <param name="angle2"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    public Vector3 GetSpherePosition(float angle1, float angle2, float radius)
    {
        float x = radius * Mathf.Sin(angle1 * Mathf.Deg2Rad) * Mathf.Cos(angle2 * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle1 * Mathf.Deg2Rad) * Mathf.Sin(angle2 * Mathf.Deg2Rad);
        float z = radius * Mathf.Cos(angle1 * Mathf.Deg2Rad);
        return new Vector3(x, y, z);
    }

    #region プロパティ
    /// <summary>
    /// メディエーター
    /// </summary>
    public Mediator Mediator
    {
        get { return m_mediator; }
    }
    #endregion
}
