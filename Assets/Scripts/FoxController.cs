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
    [SerializeField] private int tickToNextState=3;
    [SerializeField] private int numberOfIdleAnim, numberOfPrepareAnim, numberOfAttackAnim;
    [SerializeField] private AnimationClip[] idleAnim, prepareAnim, attackAnim;
    int tickCounter;
    private void Start()
    {
 
        metronome.OnTick.AddListener(Tick);
    }

    void Tick()
    {
        Debug.Log("Tick");
        tickCounter++;
        if (tickCounter>=tickToNextState)
        {
            ChangeToNextState();
            tickCounter = 0;
        }
    }
    void ChangeToNextState()
    {


        switch (currentState)
        {
            case State.Idle:

                animator.SetInteger("currentAnim", 1);
                PlayRandomAnim("IdleIndex",5);
                Debug.Log("Idle");
                currentState = State.Prepare;
                break;

            case State.Prepare:

                animator.SetInteger("currentAnim", 2);
                PlayRandomAnim("PrepareIndex", 5);
                Debug.Log("Prepare");
                currentState = State.Attack;
                break;

            case State.Attack:
                animator.SetInteger("currentAnim", 0);
                PlayRandomAnim("AttackIndex", 10);
                Debug.Log("Attack");
                currentState = State.Idle;
                break;

        }
    }
    void PlayRandomAnim(string name,int clipCount)
    {
        int randomIndex = Random.RandomRange(0,clipCount-1);
        animator.SetFloat(name, randomIndex);

    }
}
