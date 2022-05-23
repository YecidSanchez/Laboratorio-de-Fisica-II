using UnityEngine;

public static class CalcLoads {
    public static void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velocity, float force = 1, ForceMode mode = ForceMode.Force) {
        if (rigidbody.velocity.magnitude == 0) {
            rigidbody.AddForce(velocity * force, mode);
        }
        else {
            var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody.velocity) / velocity.magnitude);
            rigidbody.AddForce((velocity - velocityProjectedToTarget) * force, mode);
        }
    }
}