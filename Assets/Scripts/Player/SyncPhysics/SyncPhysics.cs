using UnityEngine;

public class SyncPhysics : MonoBehaviour
{
    private Rigidbody _rb;
    private ConfigurableJoint _joint;

    [SerializeField] private Rigidbody animatedRigidbody;
    [SerializeField] private bool syncAnimation = false;

    private Quaternion starLocalRotation;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _joint = GetComponent<ConfigurableJoint>();
        starLocalRotation = transform.localRotation;
    }

    public void UpdateJoinFromAnimation()
    {
        if(!syncAnimation) return;

        ConfigurableJointExtensions.SetTargetRotationLocal(_joint, animatedRigidbody.transform.localRotation, starLocalRotation);
    }
}
