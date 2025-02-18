using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object To Destroy")
        {            
            // get object data
            ObjectToDestroy _scriptObjectToDestroy = other.gameObject.GetComponent<ObjectToDestroy>();

            // check if dead
            if (_scriptObjectToDestroy.isObjectDead)
                return;

            // apply damage
            _scriptObjectToDestroy.objectHealth -= 1;
            Debug.Log(_scriptObjectToDestroy.objectHealth);

            // check for death
            if (_scriptObjectToDestroy.objectHealth <= 0)
                _scriptObjectToDestroy.ChangeToDead();

        }
    }

}
