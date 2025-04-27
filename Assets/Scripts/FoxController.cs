using UnityEngine;

[System.Serializable]

public class FoxController : MonoBehaviour
{
    [SerializeField] private Metronome metronome;

    enum poseState
    {
        idle,
        prepare,
        attack
    }

    [SerializeField] private GameObject[] idlePoses;
    [SerializeField] private int minIdleTickCount, maxIdleTickCount;
    [SerializeField] private int randomIdleTickCount;

    [SerializeField] private GameObject[] preparePoses, attackPoses;
    [SerializeField] private int minPrepareTickCount, maxPrepareTickCount;
    [SerializeField] private int randomPrepareTickCount;
    [SerializeField] int tickToAttack;

    [SerializeField] private AudioClip[] prepareSound;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private int prepareSoundVolume, attackSoundVolume;

    private int currentPreparePoseIndex;

    [SerializeField] private poseState currentPoseState;
    public int tickCounter;

    private void Start()
    {
        metronome.OnTick.AddListener(Tick);
        HideAllPoses();
        RandomIdlePose();
        ChangeState(currentPoseState);
        randomIdleTickCount = Random.Range(minIdleTickCount, maxIdleTickCount); // random Idle Tick
    }

    void Tick()
    {
        tickCounter++;

        if (currentPoseState == poseState.idle && tickCounter >= randomIdleTickCount)
        {
            tickCounter = 0;
            randomPrepareTickCount = Random.Range(minPrepareTickCount, maxPrepareTickCount); // random Prepare Tick
            currentPoseState = poseState.prepare;

            int randomIndex = Random.Range(0,prepareSound.Length);
            AudioManager.Instance.PlayOneShot(prepareSound[randomIndex], prepareSoundVolume);

            HideAllPoses();
            RandomPreparePose();



        }
        else if (currentPoseState == poseState.prepare && tickCounter >= tickToAttack)
        {
            tickCounter = 0;
            currentPoseState = poseState.attack;
            AudioManager.Instance.PlayOneShot(attackSound, attackSoundVolume);

            HideAllPoses();
            attackPoses[currentPreparePoseIndex].SetActive(true);


        }
        else if (currentPoseState == poseState.attack && tickCounter >= randomPrepareTickCount)
        {
            tickCounter = 0;
            randomIdleTickCount = Random.Range(minIdleTickCount, maxIdleTickCount); // random Idle Tick
            currentPoseState = poseState.idle;

            HideAllPoses();
            RandomIdlePose();
        }
    }

    void HideAllPoses()
    {
        foreach (GameObject go in idlePoses)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in preparePoses)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in attackPoses)
        {
            go.SetActive(false);
        }
    }

    void RandomIdlePose()
    {

        int randomIndex = Random.Range(0, idlePoses.Length);
        idlePoses[randomIndex].SetActive(true);

    }
    void RandomPreparePose()
    {

        currentPreparePoseIndex = Random.Range(0, preparePoses.Length);
        preparePoses[currentPreparePoseIndex].SetActive(true);

    }

    void ChangeState(poseState poseState)
    {
        switch (poseState)
        {
            case poseState.idle:


                break;

            case poseState.prepare:


                break;

            case poseState.attack:


                break;


        }

    }
}
