using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void SetBool(string param, bool value)
    {
        anim.SetBool(param, value);
    }

}
