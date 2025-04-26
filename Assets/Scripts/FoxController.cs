using UnityEngine;

[System.Serializable]
public class PosesCollection
{
    public string name;
    public int minTick;
    public int maxTick;
    public GameObject[] poses;
}
public class FoxController : MonoBehaviour
{
    [SerializeField] private Metronome metronome;
    [SerializeField] PosesCollection[] posesCollection;

    public int tickCounter;
    public int tickToNextPose;
   public int currentPosesCollectionIndex;
    private void Start()
    {
        HideAllPose();
        metronome.OnTick.AddListener(Tick);
        RandomTickCountNumber();
    }

 

    void Tick()
    {
        
        tickCounter++;

        if (tickCounter>=tickToNextPose)
        {
            if (currentPosesCollectionIndex < posesCollection.Length-1) currentPosesCollectionIndex++;
            else currentPosesCollectionIndex = 0;
            tickCounter = 0;

            HideAllPose();
            int randomPoseIndex = Random.Range(0, posesCollection[currentPosesCollectionIndex].poses.Length-1);
            ShowPose(posesCollection[currentPosesCollectionIndex], randomPoseIndex);

            RandomTickCountNumber();
        }

    }

    public void HideAllPose()
    {
        Debug.Log("Hide");
        for (int i=0;i<posesCollection.Length;i++)
        {
            for (int j = 0; j <posesCollection[i].poses.Length; j++)
            {
                posesCollection[i].poses[j].SetActive(false);
            }
        }
    }
    public void ShowPose(PosesCollection posesCollection,int poseIndex)
    {
        posesCollection.poses[poseIndex].SetActive(true);
    }
    private void RandomTickCountNumber()
    {
      tickToNextPose = Random.Range(posesCollection[currentPosesCollectionIndex].minTick, posesCollection[currentPosesCollectionIndex].maxTick);
    }
}
