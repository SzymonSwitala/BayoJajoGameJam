using UnityEngine;

public class FoxController : MonoBehaviour
{
    private enum State
    {
        Idle,
        Prepare,
        Attack
    }
    [SerializeField] private State currentState;
    [SerializeField] private Animator animator;
    [SerializeField] private Metronome metronome;
  

    void ChangeState(State state)
    {
        currentState = state;

        switch (currentState)
        {
            case State.Idle:

                break;

            case State.Prepare:

                break;

            case State.Attack:

                break;

        }
    }

}
