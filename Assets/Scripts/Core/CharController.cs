using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public Vector2 CurrentMovement { get; private set; }
    public bool NormalMovement { get; set; }

    void Start()
    {
        NormalMovement = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(NormalMovement)
        {
            MoveChar();
        }
    }

    private void MoveChar()
    {
        Vector2 currentMovePosition = rb.position + CurrentMovement * Time.fixedDeltaTime;
        rb.MovePosition(currentMovePosition);
    }

    public void MovePosition(Vector2 newPosition)
    {
        rb.MovePosition(newPosition);
    }


    public void SetMovement(Vector2 newPosition)
    {
        CurrentMovement = newPosition;
    }
}
