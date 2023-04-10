using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float appliedForce;
    [SerializeField] private PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            transform.localScale = playerMovement.isFacingRight ? Vector3.one : new Vector3(-1, 1, 1); //ajustar position en escena para que haga espejo
            col.attachedRigidbody.AddForce(Vector3.right*appliedForce,ForceMode2D.Impulse);
        }
    }
}
