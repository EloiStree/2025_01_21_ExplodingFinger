using UnityEngine;

public class ApplyExplosionForceToTouchMono : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        ContactPoint contact = contactPoints[0];
        Vector3 contactPoint = contact.point;

        if (collision != null) { 
        
            if (collision.gameObject.GetComponent<AffectedByExplosionTag>() != null)
            {
                Vector3 explosionPos = contactPoint;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 5);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.AddExplosionForce(m_explosionForce, explosionPos, m_explosionRadius, m_upwardsModifier, m_forceMode);
                    }
                }
            }
        }
    }

    public float m_explosionForce = 1000;
    public float m_explosionRadius=5;
    public float m_upwardsModifier = 3.0f;
    public ForceMode m_forceMode = ForceMode.Impulse;

}
