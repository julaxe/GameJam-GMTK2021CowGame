using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBridge : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Material ropeMaterial;
    public Material laserMaterial;

    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegLen = 0.25f;
    private int segmentLength = 35;
    private float lineWidth = 0.1f;
    private float friction = 0.1f;

    private EdgeCollider2D edgeCollider;
    private bool laserOn = false;

    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        this.edgeCollider = this.GetComponent<EdgeCollider2D>();

        Vector3 ropeStartPoint = player1.position;

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.DrawRope();

        //laser - switch
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            laserOn = !laserOn;
            if (laserOn)
            {
                SoundManagerScript.PlaySound("changeRope");
            }
        }
    }

    private void FixedUpdate()
    {
        //physics simulation
        this.Simulate();

        if (laserOn)
        {
            lineRenderer.material = laserMaterial;
        }
        else
        {
            lineRenderer.material = ropeMaterial;
        }
    }

    private void Simulate()
    {
        // SIMULATION
        Vector2 forceGravity = new Vector2(0f, 0f);

        List<Vector2> linePositions = new List<Vector2>();

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            velocity *= (1 - friction);
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;

            //edgecollider
            linePositions.Add(this.ropeSegments[i].posNow);
        }

        edgeCollider.points = linePositions.ToArray();
        //CONSTRAINTS
        for (int i = 0; i < 50; i++)
        {
            this.ApplyConstraint();
        }

    }

    private void ApplyConstraint()
    {
        //Constrant to First Point 
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = this.player1.position;
        this.ropeSegments[0] = firstSegment;


        //Constrant to Second Point 
        RopeSegment endSegment = this.ropeSegments[this.ropeSegments.Count - 1];
        endSegment.posNow = this.player2.position;
        this.ropeSegments[this.ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegLen);
            Vector2 changeDir = Vector2.zero;

            if (dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector2 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        
        
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
            
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
        
    }

    public struct RopeSegment
    {
        public Vector2 posNow;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (laserOn)
        {
            if(collision.gameObject.tag == "HolyCow")
            {
                //destroy the holy cow
                collision.gameObject.GetComponent<HolyCowHealthCount>().DeadByLasor();
            }
            if (collision.gameObject.tag == "DemonCow")
            {
                collision.gameObject.GetComponent<DemonCowAgentMoving>().killCow();                
                
            }
        }
        else //if the laser is off - it behaves like a normal rope
        {
            //We can implement another behavior here but for now, do nothing.
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (laserOn)
        {
            if (collision.gameObject.tag == "HolyCow")
            {
                //destroy the holy cow
                
            }
            if (collision.gameObject.tag == "DemonCow")
            {
                //destroy the demon cow
                //Destroy(collision.gameObject);
            }
        }
        else //if the laser is off - it behaves like a normal rope
        {
            //We can implement another behavior here but for now, do nothing.
        }
    }
}
