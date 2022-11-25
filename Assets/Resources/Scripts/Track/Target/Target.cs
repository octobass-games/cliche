using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class Target : MonoBehaviour
{
    public Conductor Conductor;
    public SpriteRenderer InnerRenderer;

    private BoxCollider2D Collider;
    private Collider2D[] OverlappingColliders = new Collider2D[10];
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
            Collider2D furthestLeftCollider = OverlappingColliders[0];

            for (int i = 0; i < overlappingColliderCount; i++)
            {
                Collider2D noteCollider = OverlappingColliders[i];

                if (i == 0 || noteCollider.transform.position.x < furthestLeftCollider.transform.position.x)
                {
                    furthestLeftCollider = noteCollider;
                }

            }

            float distanceFromCentre = Mathf.Abs((furthestLeftCollider.bounds.center - Collider.bounds.center).x);
            furthestLeftCollider.GetComponent<Note>().Play();
           
            return new TargetStrikeResult(distanceFromCentre, furthestLeftCollider.gameObject.transform.parent.gameObject);
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
        if (!collider.gameObject.GetComponent<Note>().Played)
        {
            Conductor.MissedNote(collider.gameObject.transform.parent.gameObject);
        }
    }

    private IEnumerator HighlightIndicator()
    {
        if (!IsHighlighted)
        {
            Color originalColor = InnerRenderer.color;

            InnerRenderer.color = Color.white;
            IsHighlighted = true;

            yield return new WaitForSeconds(0.1f);

            InnerRenderer.color = originalColor;
            IsHighlighted = false;
        }
    }
}
