using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seedling : MonoBehaviour
{

    public Slider progressBar;
    public bool complete;
    public bool interactable = false;
    public float currentProgress;
    public float maxProgress = 5;

    public GameObject image;

    public GameObject pivot;

    public GameObject treeCounterObject;

    private ForestTracker treeCounter;

    public float fadeOutTime;

    public GameObject player;
    private bool soundPlayed = false;
    private Color startingColour;

    public Text noWaterText;
    string taskCompletedSound = "TaskComplete";


    //private Coroutine co;

    // Start is called before the first frame update
    void Start()
    {
        if (noWaterText != null)
        {
            startingColour = noWaterText.color;
        }
        currentProgress = 0;
        complete = false;
        progressBar.value = CalculateProgress();
        progressBar.gameObject.SetActive(false);
        pivot.transform.localScale = new Vector3(1, 1, 0);
        if(treeCounterObject != null)
        treeCounter = treeCounterObject.GetComponent<ForestTracker>();
        //co = StartCoroutine(StartGlow());
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the progress bar is finished and disables tree
        if (Input.GetKey("e") && interactable && currentProgress > 5)
        {
            AudioManager.instance.Play(taskCompletedSound);
            AchievementManager.instance.IncrementAchievement(AchievementType.PlantingTrees);
            interactable = false;
            image.SetActive(false); 
            complete = true;
            progressBar.gameObject.SetActive(false);
            player = GameObject.FindWithTag("Player");
            ShootWater shootWater = player.GetComponent<ShootWater>(); ;
            shootWater.DecreaseAmmoCount();
            if (!soundPlayed)
            {
                AudioManager.instance.Play(taskCompletedSound);
                soundPlayed = true;
            }
            if(treeCounter != null)
            treeCounter.UpdateAndDisplayTaskCounter();
        }
        // updates the progress bar and increases the scale of seedling sprite 
        if (Input.GetKey("e") && interactable && !player.GetComponent<ShootWater>().isEmpty())
        {
            
            float time = Time.deltaTime;
            currentProgress += time;
            progressBar.value = CalculateProgress();
            pivot.transform.localScale += new Vector3(time, time, 0);
        }else{
             if (Input.GetKey("e") && interactable && player.GetComponent<ShootWater>().isEmpty())
        {
                if (noWaterText != null)
                {
                    noWaterText.color = startingColour;
                    noWaterText.text = "Refill your water to grow the tree!";
                    StartCoroutine(TextFadeOutRoutine());
                }

        }
        }
        // if (Input.GetKeyUp("e") && currentProgress < maxProgress)
        // {
        //     currentProgress = 0;
        //     progressBar.value = CalculateProgress();
        //     pivot.transform.localScale = new Vector3(1, 1, 0);
        // }

    }

 public IEnumerator TextFadeOutRoutine()
    {
        Color color = noWaterText.color;

        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            noWaterText.color = Color.Lerp(color, Color.clear, Mathf.Min(1, t / fadeOutTime));

            yield return null;
        }
    }
    // calculates the current progress of bar
    private float CalculateProgress()
    {
        return currentProgress / maxProgress;
    }

    // gets called when player object enters circle collider of seedling
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player") && complete == false)
        {
            interactable = true;
            progressBar.gameObject.SetActive(true);
        }
    }

    // gets called when player object exits circle collider of seedling
    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player") && complete == false)
        {
            interactable = false;
            // currentProgress = 0;
            progressBar.gameObject.SetActive(false);
            // if (complete != true)
            //     pivot.transform.localScale = new Vector3(1, 1, 0);
        }
    }

    //private IEnumerator StartGlow()
    //{
    //    while (true)
    //    {
    //        for (float i = 1; i <= 3; i += Time.deltaTime)
    //        {
    //           gameObject.GetComponent<SpriteGlowEffect>().outlineWidth = i;

    //            yield return null;
    //        }

    //        for (float i = 3; i <= 1; i -= Time.deltaTime)
    //        {
    //            gameObject.GetComponent<SpriteGlowEffect>().outlineWidth = i;

    //            yield return null;
    //        }

    //    }
    //}


}
