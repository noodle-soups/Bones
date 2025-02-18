using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object To Destroy")
        {
            Debug.Log("Hit");
        }
    }

}
