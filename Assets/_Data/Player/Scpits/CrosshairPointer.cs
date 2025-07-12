using UnityEngine;
using UnityEngine.EventSystems;

public class CrosshairPointer : SaiBehavior
{
    protected float maxDistance = 100f;
    protected Collider hitObj;
    [SerializeField] LayerMask layerMask = -1;

    protected virtual void LateUpdate()
    {
        this.Pointing();
    }

    protected virtual void Pointing()
    {
        Vector3 screenCenter = new(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        {
            transform.position = hit.point;
            this.hitObj = hit.collider;
        }
    }
}