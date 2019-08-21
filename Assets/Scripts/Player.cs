using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    private float timeVal; // rest fire cd = fireCD - timeVal
    private float shieldTimeVal;

    public float speed;
    public float shieldTime;
    public float fireCD;
    public Sprite[] sprites;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject shieldPrefab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        shieldTimeVal = shieldTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldTimeVal >= 0)
        {
            shieldPrefab.SetActive(true);
            shieldTimeVal -= Time.deltaTime;
            if (shieldTimeVal < 0)
            {
                shieldPrefab.SetActive(false);
            }
        }

        if (timeVal >= fireCD)
        {
            Fire();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            timeVal = 0;
        }
    }

    private void Die()
    {
        if (shieldTimeVal >= 0)
        {
            return;
        }

        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private int UpdateMotivation()
    {
        float v = Input.GetAxisRaw("Vertical");
        int moving = 0;
        if (v == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            moving = 1;
        }
        if (v == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moving = 1;
        }

        float h = Input.GetAxisRaw("Horizontal");
        if (h == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            moving = 1;
        }
        if (h == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            moving = 1;
        }

        return moving;
    }

    private void Move()
    {
        int moving = UpdateMotivation();
        transform.Translate(moving * transform.up * speed * Time.fixedDeltaTime, Space.World);
    }
}
