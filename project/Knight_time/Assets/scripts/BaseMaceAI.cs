using UnityEngine;
using System.Collections;

public class BaseMaceAI : MonoBehaviour
{
    public float Speed;
    public float Distance;
    public float StartingDistance;
    public GameObject Player;
    public GameObject PlayerLaunchController;
    public GameObject RotationPivot;
    public float LaunchPower;
    public float LaunchHeight;
    public float MinTimeBetweenLaunches;

    private float TimeTracker;

    private static float LaunchedTimeTracker;
    private static bool Launchable = true;

    private static int InstCount;
    private static int EvalSoFar;
    // Use this for initialization
    void Start () {
        TimeTracker = 0;
    }
    void OnEnable()
    {
        Debug.Log("fuck");
        InstCount++;
    }
    // Update is called once per frame
    void Update() {
        if (!Launchable)
        {
            if (EvalSoFar == 0)
            {
                LaunchedTimeTracker += Time.deltaTime;
            }
            EvalSoFar++;
            if(EvalSoFar == InstCount)
            {
                EvalSoFar = 0;
            }
            if(LaunchedTimeTracker > MinTimeBetweenLaunches)
            {
                LaunchedTimeTracker = 0;
                Launchable = true;
            }
        }

        Vector3 v = transform.localPosition;
        v.y = Distance * Mathf.Sin(Speed * (TimeTracker += Time.deltaTime)) + StartingDistance;
        transform.localPosition = v;
      //  Vector3 w = transform.eulerAngles;
       // w.x += Mathf.Rad2Deg * Speed * Time.deltaTime;
       // Debug.Log(Mathf.Rad2Deg * Speed * Time.deltaTime);
        //Debug.Log(w.x);
        //Quaternion q = Quaternion.Euler(w);
        //transform.rotation = q;
        transform.Rotate(transform.right, Mathf.Rad2Deg * - Speed * Time.deltaTime, Space.World);

        Vector3 position = Player.transform.position;
        position.y = RotationPivot.transform.position.y;
        RotationPivot.transform.LookAt(position);
    }

    public void LaunchThePlayer()
    {
        if (Launchable)
        {
            Vector3 position = Player.transform.position;
            position.y = RotationPivot.transform.position.y;
            position -= RotationPivot.transform.position;

            Rigidbody rb = Player.GetComponent<Rigidbody>();

            PlayerLaunchController.GetComponent<EnableComponentOnTriggerEnter>().Launch();

            position.Normalize();
            position.y = LaunchHeight;
            rb.AddForce(position * LaunchPower);

            Launchable = false;
        }
    }

    void OnDisable()
    {
        InstCount--;
    }
}
