using System.Collections;
using UnityEngine;
using UnityEngine.Networking.Types;

class PowerUp : MonoBehaviour

{
    public Health PlayerHealth;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            PlayerHealth = collision.gameObject.GetComponent<Health>();
            // StartCoroutine(NoDamage());
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
 
    // IEnumerator NoDamage () 
    // {
    //    PlayerHealth.enabled = false;
    //    Debug.Log ("Health Disabled " + PlayerHealth.HP);
    //    yield return new WaitForSeconds(5);
    //    Debug.Log ("Health Enabled " + PlayerHealth.HP);
 
    //    PlayerHealth.enabled = true;
    //    Destroy(gameObject);
 
    // }
}
