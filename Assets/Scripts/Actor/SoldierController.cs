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

    // 空集合　ファイ
    private float m_phi;
    // シータ
    private float m_theta;


    /// <summary>
    /// 開始処理
    /// </summary>
    private void Start()
    {
        // メディエーターの作成
        m_mediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<Mediator>();

        // 基底クラスの開始処理
        //base.Start();
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

        // デバッグ
        {
            //// 球の半径
            //float earthR = 10;
            //// 球の上ベクトルとオブジェクトの前方ベクトルの内積を取得
            //float dot = Vector3.Dot(m_mediator.Earth.transform.up, this.transform.up);
            //// 座標xを取得cos
            //float posX = earthR * dot;
            //// 三角関数の相互関係よりy座標を取得
            //float posY = Mathf.Sqrt(1 - (dot * dot));
            //Debug.Log(new Vector2(posX, posY));

            // 地球とオブジェクトの内積を求める
            m_theta = Mathf.Asin(this.transform.position.y / 10);
            m_phi = Mathf.Atan(this.transform.position.x / this.transform.position.z);
            //float a = Vector3.Dot()
            //Debug.Log(GetPosition(angle1, angle2, 10));
        }

        // 基底クラスの更新処理
        //base.Update();
    }

    public Vector3 GetPosition(float angle1, float angle2, float radius)
    {
        float x = radius * Mathf.Sin(angle1 * Mathf.Deg2Rad) * Mathf.Cos(angle2 * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle1 * Mathf.Deg2Rad) * Mathf.Sin(angle2 * Mathf.Deg2Rad);
        float z = radius * Mathf.Cos(angle1 * Mathf.Deg2Rad);
        return new Vector3(x, y, z);
    }
}
