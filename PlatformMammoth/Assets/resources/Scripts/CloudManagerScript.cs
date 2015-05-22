using UnityEngine;
using System.Collections;

public class CloudManagerScript : MonoBehaviour
{

    private float speed = .5f;
    private bool setDirection = false;
    // Use this for initialization
    void Start()
    {
        if (Random.value > .5f)
        {
            setDirection = true;
        }
        else
        {
            setDirection = false;
        }
    }

    void Update() 
    {
        if (setDirection) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else 
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }
}
