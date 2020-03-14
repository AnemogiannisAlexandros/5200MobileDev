using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    public static PlayerManager Instance { get { return _instance;} }

    public Vector2 checkpointPos;
    private float respawnTimer = 0;
    public bool IsDead { get; set; }
    public int Health { get; set; }

    private void Awake()
    {
        if (_instance == null && _instance!=this)
        {
            _instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
        Health = 1;
    }

    private void Update()
    {
        if (IsDead) 
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer >= 3) 
            {
                transform.position = checkpointPos;
                FindObjectOfType<AnimationHandler>().SetRespawn();
                Health = 1;
                IsDead = false;
                respawnTimer = 0;
            }
        }
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            IsDead = true;
            Debug.Log("Player is dead");
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Boss"))
        {
            IsDead = true;
            Debug.Log("DEAD");
        }
    }
}
