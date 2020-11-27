using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SnakeGameControl : MonoBehaviour {
    public static GameObject cat;
    public GameObject certainPosition;
    public static int diceSideThrown = 0;
    public static int StartWaypoint = 0;
    public GameObject panel;
    public GameObject finalMessage;
    public static bool gameOver = false;
       
    void Start ()
    {     
        cat = GameObject.Find("cat");      
        cat.GetComponent<FollowThePath>().moveAllowed = false;       
    }

    void OnEnable()
    {
       StartWaypoint = 0;
    }
    void Update()
    {
        if (cat.GetComponent<FollowThePath>().waypointIndex > 
            StartWaypoint + diceSideThrown)
        {
            cat.GetComponent<FollowThePath>().moveAllowed = false;           
            StartWaypoint = cat.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        certainPosition.GetComponent<Text>().text = cat.GetComponent<FollowThePath>().waypointIndex.ToString();
        if (certainPosition.GetComponent<Text>().text == "3")
        {
            if (cat.GetComponent<FollowThePath>().moveAllowed == false)
            {
                certainPosition.GetComponent<Text>().text = "3";
                transform.position = Vector2.MoveTowards(transform.position,
                cat.GetComponent<FollowThePath>().waypoints[1].transform.position,
                cat.GetComponent<FollowThePath>().moveSpeed * Time.deltaTime);
                cat.GetComponent<FollowThePath>().moveAllowed = true;
                diceSideThrown = 0;
                StartWaypoint = cat.GetComponent<FollowThePath>().waypointIndex = 14;
            }
        }

        if (certainPosition.GetComponent<Text>().text == "11")
        {
            if (cat.GetComponent<FollowThePath>().moveAllowed == false)
            {
                certainPosition.GetComponent<Text>().text = "11";
                transform.position = Vector2.MoveTowards(transform.position,
                cat.GetComponent<FollowThePath>().waypoints[1].transform.position,
                cat.GetComponent<FollowThePath>().moveSpeed * Time.deltaTime);
                cat.GetComponent<FollowThePath>().moveAllowed = true;
                diceSideThrown = 0;
                StartWaypoint = cat.GetComponent<FollowThePath>().waypointIndex = 22;
            }
        }

        if (certainPosition.GetComponent<Text>().text == "12")
        {
            if (cat.GetComponent<FollowThePath>().moveAllowed == false)
            {
                certainPosition.GetComponent<Text>().text = "12";
                transform.position = Vector2.MoveTowards(transform.position,
                cat.GetComponent<FollowThePath>().waypoints[1].transform.position,
                cat.GetComponent<FollowThePath>().moveSpeed * Time.deltaTime);
                cat.GetComponent<FollowThePath>().moveAllowed = true;
                diceSideThrown = 0;
                StartWaypoint = cat.GetComponent<FollowThePath>().waypointIndex = 3;
            }
        }

        if (certainPosition.GetComponent<Text>().text == "21")
        {
            if (cat.GetComponent<FollowThePath>().moveAllowed == false)
            {
                certainPosition.GetComponent<Text>().text = "21";
                transform.position = Vector2.MoveTowards(transform.position,
                cat.GetComponent<FollowThePath>().waypoints[1].transform.position,
                cat.GetComponent<FollowThePath>().moveSpeed * Time.deltaTime);
                cat.GetComponent<FollowThePath>().moveAllowed = true;
                diceSideThrown = 0;
                StartWaypoint = cat.GetComponent<FollowThePath>().waypointIndex = 28;
            }
        }
        if (certainPosition.GetComponent<Text>().text == "25")
        {
            if (cat.GetComponent<FollowThePath>().moveAllowed == false)
            {
                certainPosition.GetComponent<Text>().text = "9";
                transform.position = Vector2.MoveTowards(transform.position,
                cat.GetComponent<FollowThePath>().waypoints[1].transform.position,
                cat.GetComponent<FollowThePath>().moveSpeed * Time.deltaTime);
                cat.GetComponent<FollowThePath>().moveAllowed = true;
                diceSideThrown = 0;
                StartWaypoint = cat.GetComponent<FollowThePath>().waypointIndex = 9;
            }
        }

        if (certainPosition.GetComponent<Text>().text == "30")
        {
            if (cat.GetComponent<FollowThePath>().moveAllowed == false)
            {
                certainPosition.GetComponent<Text>().text = "30";
                transform.position = Vector2.MoveTowards(transform.position,
                cat.GetComponent<FollowThePath>().waypoints[1].transform.position,
                cat.GetComponent<FollowThePath>().moveSpeed * Time.deltaTime);
                cat.GetComponent<FollowThePath>().moveAllowed = true;
                diceSideThrown = 0;
                StartWaypoint = cat.GetComponent<FollowThePath>().waypointIndex = 17;
            }
        }             

        if (cat.GetComponent<FollowThePath>().waypointIndex == 
            cat.GetComponent<FollowThePath>().waypoints.Length)
        {
            finalMessage.SetActive(true);
            panel.SetActive(false);
        }             
    }

    public static void MovePlayer()
    {
            cat.GetComponent<FollowThePath>().moveAllowed = true;
    }
}