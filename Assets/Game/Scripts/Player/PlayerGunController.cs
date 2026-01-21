using System;
using System.Drawing;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] private float FollowSpeed = 5f;

    [SerializeField] private Transform[] GunSlots;

    [SerializeField] private Transform Target;

    private Transform[] Guns;
    int GunLength => Guns.Length;
    Quaternion CalcRotation;
    private void Awake()
    {
        // Script Variables initailization
        Guns = new Transform[GunSlots.Length];
    }
    private void Start()
    {
        UpdateGunDetails();
    }

    private void Update()
    {
        for (int i = 0; i < GunLength; i++)
        {
            if (Guns[i] == null) continue;
            CalcRotation = (CanAimAtTarget(Guns[i], Target)) ? Quaternion.LookRotation(Target.position - Guns[i].position) : Quaternion.LookRotation(transform.forward * 10 - Guns[i].position);
            Guns[i].rotation = Quaternion.Lerp(Guns[i].rotation, CalcRotation, Time.deltaTime * FollowSpeed);
        }
    }

    private bool CanAimAtTarget(Transform transform, Transform target)
    {
        Transform player = this.transform;
        Vector3 point = target.position;
        float maxDistance = 1000f;
        float fieldOfViewAngle = 90;

        Vector3 directionToPoint = point - player.position;
        float distance = directionToPoint.magnitude;

        if (distance > maxDistance)
            return false;

        directionToPoint.Normalize();

        float angle = Vector3.Angle(player.forward, directionToPoint);

        return angle <= fieldOfViewAngle * 0.5f;
    }

    private void UpdateGunDetails()
    {

        for (int i = 0; i < GunSlots.Length; i++)
        {
            //Check If Gun Exists in Slot
            if (GunSlots[i].childCount == 1)
            {
                Guns[i] = GunSlots[i].GetChild(0);
            }
            else if (GunSlots[i].childCount == 0)
            {
                Guns[i] = null;
            }
            else
            {
                Debug.LogError("More than one gun in slot: " + GunSlots[i].name);
            }
        }
    }
}
