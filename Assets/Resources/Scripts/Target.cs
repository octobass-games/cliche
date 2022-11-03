using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Target : MonoBehaviour
{
    private BoxCollider2D Collider;
    private Collider2D[] OverlappingColliders = new Collider2D[1];
    private ContactFilter2D ContactFilter = new ContactFilter2D().NoFilter();

    private void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
    }

    public float DistanceFromCentre()
    {
        int overlappingColliderCount = Collider.OverlapCollider(ContactFilter, OverlappingColliders);

        if (overlappingColliderCount > 0)
        {
            Collider2D overlappingCollider = OverlappingColliders[0];

            return Mathf.Abs((overlappingCollider.bounds.center - Collider.bounds.center).x);
        }

        return float.PositiveInfinity;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        
    }
}
