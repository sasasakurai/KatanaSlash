using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAnimationName : MonoBehaviour
{
    public Animator animator;  // �A�^�b�`����Animator�R���|�[�l���g
    public TextMeshProUGUI animationNameText;  // �\������UI��Text�R���|�[�l���g

    void Update()
    {
        if (animator != null && animationNameText != null)
        {
            // ���ݍĐ����̃X�e�[�g�����擾
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // �A�j���[�V���������擾
            string animationName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            // TextMeshPro UI�ɕ\��
            animationNameText.text = $"Animation: {animationName}";
        }
    }
}

