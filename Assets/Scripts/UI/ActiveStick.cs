//
// ActiveStick.cs
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アクティブ状態クラス
/// </summary>
public class ActiveStick : UIState
{

    // 可動範囲
    private const float ACTIVE_RANGE = 30;


    // UI画像
    private Image m_image;
    // スティック
    private StickController m_stick;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="uiBase">UIベース</param>
    public ActiveStick(UIBase uiBase):
        base(uiBase)
    {
        // イメージの作成
        m_image = m_uiBase.GetComponent<Image>();
        // スティックの作成
        m_stick = m_uiBase.GetComponent<StickController>();
    }

    /// <summary>
    /// 実行
    /// </summary>
	public override void Execute()
    {
        // スティックを「なし」状態に変更
        if (!Input.GetMouseButton(0))
        {
            m_uiBase.ChangeState(new NoneStick(m_uiBase));
        }

        // マウス座標
        Vector2 mousePos = Input.mousePosition;
        // 画像の座標
        Vector2 imagePos = m_image.rectTransform.position;
        // 画僧の元座標
        Vector2 origin = m_uiBase.GetComponent<StickController>().Origin;

        // ザウスの座標に設定する
        imagePos = mousePos;

        // 可動範囲外で処理を止める
        m_stick.Flag.Off(m_stick.ROTATE_LEFT);
        if (imagePos.x < origin.x - ACTIVE_RANGE)
        {
            imagePos.x = origin.x - ACTIVE_RANGE;
            m_stick.Flag.On(m_stick.ROTATE_LEFT);
        }
        m_stick.Flag.Off(m_stick.ROTATE_RIGHT);
        if (imagePos.x > origin.x + ACTIVE_RANGE) 
        {
            imagePos.x = origin.x + ACTIVE_RANGE;
            m_stick.Flag.On(m_stick.ROTATE_RIGHT);
        }
        m_stick.Flag.Off(m_stick.ROTATE_DOWN);
        if (imagePos.y < origin.y - ACTIVE_RANGE)
        {
            imagePos.y = origin.y - ACTIVE_RANGE;
            m_stick.Flag.On(m_stick.ROTATE_DOWN);
        }
        m_stick.Flag.Off(m_stick.ROTATE_UP);
        if (imagePos.y > origin.y + ACTIVE_RANGE)
        {
            imagePos.y = origin.y + ACTIVE_RANGE;
            m_stick.Flag.On(m_stick.ROTATE_UP);
        }

        // 座標を設定    
        m_image.rectTransform.position = imagePos;

        // 全移動フラグをオフ
        if (Input.GetMouseButtonUp(0))
        {
            m_stick.Flag.OffAll();
        }
    }
}
