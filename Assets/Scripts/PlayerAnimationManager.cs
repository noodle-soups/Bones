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

}
