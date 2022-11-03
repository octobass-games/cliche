using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Target : MonoBehaviour
{
    private BoxCollider2D Collider;
    private Collider2D[] OverlappingColliders = new Collider2D[1];
    private ContactFilter2D ContactFilter = new ContactFilter2D().NoFilter();
    public NoteType NoteType;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
    }

    public (float, Note) Hit()
    {
        Array.Clear(OverlappingColliders, 0, 1);
        int overlappingColliderCount = Collider.OverlapCollider(ContactFilter, OverlappingColliders);

        if (overlappingColliderCount > 0)
        {
            Collider2D noteCollider = OverlappingColliders[0];

            return (Mathf.Abs((noteCollider.bounds.center - Collider.bounds.center).x), noteCollider.GetComponent<Note>());
        }

        return (float.PositiveInfinity, null);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        
    }
}
