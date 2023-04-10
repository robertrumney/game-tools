using UnityEngine;

public class AnimatorKeeper : MonoBehaviour
{
    // Reference to the Animator component
    private Animator m_Animator;

    // Variable to store the normalized time of the current animation state
    private float state = 0;

    // Method to initialize the Animator reference
    private void Init()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Method called every frame to update the current state
    private void Update()
    {
        state = m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    // Method called when the script instance is being loaded
    private void OnEnable()
    {
        // If the Animator reference is null, initialize it
        if (m_Animator == null)
        {
            Init();
        }
        // If the Animator reference is not null, play the animation from the start using the stored state value
        if (m_Animator != null)
        {
            m_Animator.Play(0, 0, state);
        }
    }
}
