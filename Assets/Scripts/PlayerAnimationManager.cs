using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void SetBool(string animBoolName, bool value)
    {
        anim.SetBool(animBoolName, value);
    }

    public bool IsAnimationPlaying(string animName)
    {
        AnimatorStateInfo _stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        return _stateInfo.IsName(animName) && _stateInfo.normalizedTime < 1f;
    }

}
