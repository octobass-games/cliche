using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class Target : MonoBehaviour
{
    public NoteType NoteType;
    public Conductor Conductor;
    public SpriteRenderer InnerRenderer;

    private BoxCollider2D Collider;
    private Collider2D[] OverlappingColliders = new Collider2D[1];
    private ContactFilter2D ContactFilter = new ContactFilter2D().NoFilter();
    private bool IsHighlighted = false;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
    }

    public TargetStrikeResult GetTargetStrikeResult()
    {
        Array.Clear(OverlappingColliders, 0, 1);

        int overlappingColliderCount = Collider.OverlapCollider(ContactFilter, OverlappingColliders);

        if (overlappingColliderCount > 0)
        {
            Collider2D noteCollider = OverlappingColliders[0];

            float distanceFromCentre = Mathf.Abs((noteCollider.bounds.center - Collider.bounds.center).x);
           
            return new TargetStrikeResult(distanceFromCentre, noteCollider.gameObject);
        }

        return new TargetStrikeResult(0f, null);
    }

    public void OnStrike(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(HighlightIndicator());

            TargetStrikeResult result = GetTargetStrikeResult();

            Conductor.PlayedNote(result);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Missed note");
        Conductor.MissedNote();
    }

    private IEnumerator HighlightIndicator()
    {
        if (!IsHighlighted)
        {
            Debug.Log("Highlighting indicator");
            Color originalColor = InnerRenderer.color;

            InnerRenderer.color = Color.white;
            IsHighlighted = true;

            yield return new WaitForSeconds(0.1f);

            Debug.Log("Unhighlighting indicator");
            InnerRenderer.color = originalColor;
            IsHighlighted = false;
        }
    }
}
