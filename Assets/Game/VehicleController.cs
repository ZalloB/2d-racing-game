using UnityEngine;

public class VehicleController : MonoBehaviour {

    public Vehicle vehicle = new Vehicle();
    public float power = 3;
    public float maxspeed = 5;
    public float turnpower = 2;
    public float friction = 3;
    public Vector2 curspeed;
    Rigidbody2D actualRigidbody2D;

    // Use this for initialization
    void Start()
    {
        vehicle.BreakingReaction = friction;
        actualRigidbody2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (GameObject.Find("GameLevelManager").GetComponent<GameLevelManager>().isStarted)
            MovementController();

    }

    void MovementController()
    {
        curspeed = new Vector2(actualRigidbody2D.velocity.x, actualRigidbody2D.velocity.y);

        if (curspeed.magnitude > maxspeed)
        {
            curspeed = curspeed.normalized;
            curspeed *= maxspeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            actualRigidbody2D.AddForce(transform.up * power);
            actualRigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.S))
        {
            actualRigidbody2D.AddForce(-(transform.up) * (power / 2));
            actualRigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnpower);
        }

        Decelerate();
    }

    void Decelerate()
    {
        bool gas = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            gas = !gas;


        if (!gas)
            actualRigidbody2D.drag = friction * 2;

    }
}
