using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAnimationName : MonoBehaviour
{
    public Animator animator;  // アタッチするAnimatorコンポーネント
    public TextMeshProUGUI animationNameText;  // 表示するUIのTextコンポーネント

    void Update()
    {
        if (animator != null && animationNameText != null)
        {
            // 現在再生中のステート情報を取得
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // アニメーション名を取得
            string animationName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            // TextMeshPro UIに表示
            animationNameText.text = $"Animation: {animationName}";
        }
    }
}

