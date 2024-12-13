using System.Collections;
using UnityEngine;

public class CourageOnCollision : MonoBehaviour
{
    [SerializeField]
    private float _damage = 20f;
    [SerializeField]
    private int damaageAppliedInterval = 1;

    private bool isPlayerInCollider = false;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        isPlayerInCollider = true;
        TryToDamge(collision.collider);
    }

    private void OnCollisionExit(Collision collision)
    {
        isPlayerInCollider = false;
        //Debug.Log("stop cortouine");
    }

    private IEnumerator ApplyDamageAtRate(Health healthOfOtherObject)
    {
        while (isPlayerInCollider)
        {
            healthOfOtherObject.ApplyDamage(_damage);                                   //call ApplyDamge func that lives within Health script of object collided with. updates currentHealth
            //Debug.Log("start cortouine");
            yield return new WaitForSeconds(damaageAppliedInterval);
            //Debug.Log("damage applied " + healthOfOtherObject.HealthPercentage);
        }
    }

    private void TryToDamge(Collider collider)
    {
        if (collider.TryGetComponent(out Health healthOfOtherObject) == true                //check if object collided with has Health script attached
            && healthOfOtherObject.GetTeam != gameObject.GetComponent<Health>().GetTeam) //check if object collided with is the same team as the object this script is attached to.
                                                                                         //"team" var lives in Health script. GetTeam is Getter func for public "team" var. 
        {
                                    
                //Debug.Log("health " + healthOfOtherObject.HealthPercentage);
                StartCoroutine(ApplyDamageAtRate(healthOfOtherObject));
           
        }
    }
}
