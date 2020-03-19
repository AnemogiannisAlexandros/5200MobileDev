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
    public bool AllowInput { get; set; }
    public int Health { get; set; }
    Rigidbody2D rb;

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
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
        AllowInput = true;
        Health = 1;
        checkpointPos = transform.position;
    }

    private void Update()
    {
        if (IsDead) 
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            respawnTimer += Time.deltaTime;
            if (respawnTimer >= 3) 
            {
                transform.position = checkpointPos;
                FindObjectOfType<AnimationHandler>().SetRespawn();
                Health = 1;
                IsDead = false;
                respawnTimer = 0;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            IsDead = true;
            StartCoroutine(SceneTransitonManager.Instance.SimpleCrossFade());
        }
    }
}
