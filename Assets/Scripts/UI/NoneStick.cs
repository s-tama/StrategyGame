//
// NoneStick.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 何もしない状態
/// </summary>
public class NoneStick : UIState
{

    // UI画像
    private Image m_image;
    // 中心
    private Vector2 m_center;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="uiBase">UIベース</param>
    public NoneStick(UIBase uiBase):
        base(uiBase)
    {
        // イメージの作成
        m_image = m_uiBase.GetComponent<Image>();
    }

    /// <summary>
    /// 実行
    /// </summary>
	public override void Execute()
    {
        // 画像の座標
        Vector2 imagePos = m_image.rectTransform.position;
        // 画僧の元座標
        Vector2 origin = m_uiBase.GetComponent<StickController>().Origin;


        // 元の座標に戻す
        {
            if (imagePos.x < origin.x) imagePos.x += 5;
            if (imagePos.x > origin.x) imagePos.x -= 5;
            if (imagePos.y < origin.y) imagePos.y += 5;
            if (imagePos.y > origin.y) imagePos.y -= 5;
        }


        // 座標を設定
        m_image.rectTransform.position = imagePos;


        // 状態変更
        if (Input.GetMouseButtonDown(0))
        {
            if (IsChanged() == true)
            {
                // スティックを「アクティブ」状態に変更
                m_uiBase.ChangeState(new ActiveStick(m_uiBase));
            }
        }
    }


    /// <summary>
    /// 変更フラグ関数
    /// </summary>
    /// <returns></returns>
    private bool IsChanged()
    {
        // 画像幅
        float width = m_image.rectTransform.sizeDelta.x;
        // 画像高さ
        float height = m_image.rectTransform.sizeDelta.y;
        // 画像のx座標
        float imageX = m_image.rectTransform.position.x;
        // 画像のy座標
        float imageY = m_image.rectTransform.position.y;
        // マウス座標
        Vector2 mousePos = Input.mousePosition;

        // 範囲内でマウスがクリックされた
        if ((mousePos.x > imageX - width / 2) && (mousePos.x < imageX + width / 2)
            && (mousePos.y > imageY - height / 2) && (mousePos.y < imageY + height / 2))
        {
            return true;
        }

        return false;
    }
}
