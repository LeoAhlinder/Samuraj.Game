using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeads : MonoBehaviour
{   //Raycasts
    [SerializeField] public Transform Player;
    [SerializeField] public LayerMask Goblin;

    //Raycast bools
    public bool CloseToGoblinHead = false;

    //Floats
    public float GoblinHeads = 0;
    public float FlyingHeads = 0;
    public float SkeletonHeads = 0;
    public float RedHeads = 0;

    //Bools
    Goblin goblin;
    private bool HeadCollected = false;

    //UI text
    [SerializeField] public GameObject GoblinHeadText;
    [SerializeField] public GameObject HeadIsCollectedText;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        goblin = GameObject.Find("Goblin").GetComponent<Goblin>();
    }

    public void Update()
    {
        bool GoblinHead = Physics2D.OverlapCircle(Player.position, 0.89f, Goblin);

        if (GoblinHead)
        {
            CloseToGoblinHead = true;
        }
        if (HeadCollected == false)
        {
            if (CloseToGoblinHead)
            {
                if (goblin.health <= 0)
                {
                    GoblinHeadText.SetActive(true);
                    if (GoblinHead == false)
                    {
                        GoblinHeadText.SetActive(false);
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GoblinHeads = GoblinHeads + 1;
                        GoblinHeadText.SetActive(false);
                        HeadCollected = true;
                        HeadIsCollectedText.SetActive(true);
                        StartCoroutine(HeadCollectedTimer());
                        IEnumerator HeadCollectedTimer()
                        {
                            yield return new WaitForSeconds(2.5f);
                            HeadIsCollectedText.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
