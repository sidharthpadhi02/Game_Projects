
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;

    public Transform interactionTransform;
    public virtual void Interact()
    {
        //this method is meant to be ovewritten
        Debug.Log("Interact" + transform.name);
        if(interactionTransform.tag.Equals( Tags.POWER_UP))
        {
            Destroy(interactionTransform);
        }
    }
    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance<=radius)
            {
                
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
