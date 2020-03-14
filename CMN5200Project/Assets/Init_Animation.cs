using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Animation : MonoBehaviour
{
    private bool isFirstTime = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFirstTime && collision.gameObject.CompareTag("Player")) 
        {
            isFirstTime = false;
            GetComponent<Animator>().SetTrigger("InitBoat");
            StartCoroutine(WaitForAnim(collision));

        }
    }
    IEnumerator WaitForAnim(Collision2D collision) 
    {
        PlayerManager.Instance.AllowInput = false;
        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        collision.transform.SetParent(this.transform);
        Debug.Log("Start");
        yield return new WaitForSecondsRealtime(18);
        Debug.Log("End");
        collision.transform.SetParent(null);
        collision.transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<Animator>().enabled = false;
        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        PlayerManager.Instance.AllowInput = true;
    }
}
