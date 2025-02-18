using UnityEngine;

public class ObjectToDestroy : MonoBehaviour
{

    public float objectHealth;
    public bool isObjectDead = false;
    //public bool isObjectHittable = true;

    public void OnObjectDeath()
    {
        isObjectDead = true;
        Debug.Log("Destroy");
    }


}
