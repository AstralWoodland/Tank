using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Enemy":
                Destroy(gameObject);
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            case "Base":
                Destroy(gameObject);
                break;
            case "Wall":
                Destroy(gameObject);
                break;
            /*case "Player":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;*/
            default:
                break;
        }
    }
}
