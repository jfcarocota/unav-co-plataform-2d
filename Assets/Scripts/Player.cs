using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;

    Vector2 Axis
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    //Una vez por frame
    void Update()
    {
        transform.Translate(Axis * moveSpeed * Time.deltaTime);
    }
}
