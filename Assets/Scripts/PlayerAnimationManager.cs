using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    private Animator anim;
    public AnimatorStateInfo animStateInfo;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
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
