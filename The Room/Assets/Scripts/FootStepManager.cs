using System;
using UnityEngine;

public class FootStepManager : MonoBehaviour
{
    private Vector3 lastPos;
    private CharacterController player;

    public AudioClip normalFootStepClip;
    public AudioClip metalFootStepClip;
    
    private AudioClip clipToPlay;
    [SerializeField] private float footstepDur = .2f;
    private float lastStepPlayTime = -10f;

    private void Awake()
    {
        player = GetComponent<CharacterController>();
        clipToPlay = normalFootStepClip;
    }

    private void Update()
    {
        var vel = (transform.position - lastPos) / Time.deltaTime;
        
        var groundVel = new Vector2(vel.x, vel.z);
        if (groundVel != Vector2.zero && player.isGrounded)
        {
            if (Time.time - lastStepPlayTime >= footstepDur * (groundVel.magnitude > 4.5f ? .65f : 1f))
            {
                AudioSource.PlayClipAtPoint(
                    clipToPlay, transform.position, clipToPlay == normalFootStepClip ? 1f : .2f
                );
                lastStepPlayTime = Time.time;
            }
        }
        
        lastPos = transform.position;
    }

    public void SetClipToUse(int x) => clipToPlay = x == 0 ? normalFootStepClip : metalFootStepClip;
}
