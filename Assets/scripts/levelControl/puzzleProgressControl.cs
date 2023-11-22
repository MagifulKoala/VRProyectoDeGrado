using UnityEngine;
using UnityEngine.Events;

public class puzzlePorgressControl : MonoBehaviour
{
    [Header("First Challenge")]
    [SerializeField] ObjectControll woodBeam;


    public UnityEvent firstChallengeComplete; 


    //extra stuff
    int currentChallenge = 0; 

    private void Start()
    {
        initializeFirstChallenge();
    }


    //First challenge
    private void initializeFirstChallenge()
    {
        woodBeam.ObjectDestroyed.AddListener(woodBarrierDestroyed);
    }

    private void woodBarrierDestroyed()
    {
        firstChallengeComplete?.Invoke();
        challengeComplete(); 
    }


    //extra stuff
    public void challengeComplete()
    {
        currentChallenge++;
    }
}

