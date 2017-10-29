using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    [SerializeField] private float m_shakeStrength;
    [SerializeField] private float m_shakeLength;
    [SerializeField] [Range(0.0f, 1000.0f)] private float Speed = 10.0f;
    [SerializeField] private KeyCode m_leftKey = KeyCode.A;
    [SerializeField] private KeyCode m_rightKey = KeyCode.D;
    [SerializeField] private KeyCode m_upKey = KeyCode.W;
    [SerializeField] private KeyCode m_downKey = KeyCode.S;
    [SerializeField] private Material m_ghostMat;

    private float m_phaseTime = 0.0f;
    private float m_massTime = 0.0f;

    private Material m_baseMat;
    private Rigidbody m_myRigidBody;
    private int m_playerLayer;
    private Renderer m_myRenderer;
    private FollowCenter m_mainCameraRef;

    private float currentSpeed;
   
    // Use this for initialization
    void Awake () {
        m_myRigidBody = GetComponent<Rigidbody>();
        m_myRenderer = GetComponent<Renderer>();
        m_playerLayer = LayerMask.NameToLayer("Player");
        gameObject.layer = m_playerLayer;
        m_baseMat = m_myRenderer.material;
        m_mainCameraRef = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCenter>();
    }

    // Update is called once per frame
    void Update () {
        if (PauseManager.OnlyOne.Paused()) { StopMoving(); return; }
        float dx = (Input.GetKey(m_leftKey) ? -1.0f : 0.0f) + (Input.GetKey(m_rightKey) ? 1.0f : 0.0f);
        float dz = (Input.GetKey(m_upKey) ? 1.0f : 0.0f) + (Input.GetKey(m_downKey) ? -1.0f : 0.0f);

        m_myRigidBody.AddForce(new Vector3(dx, 0.0f, dz) * (Speed * m_myRigidBody.mass));

        m_phaseTime -= Time.deltaTime;
        m_massTime -= Time.deltaTime;
        if (m_phaseTime <= 0.0f)
        {
            m_phaseTime = 0.0f;
            ResetMat();
        }

        if (m_massTime <= 0.0f)
        {
            m_massTime = 0.0f;
            ResetScale();
        }
    }

    private void StopMoving()
    {
        m_myRigidBody.velocity = Vector3.zero;
    }

    public void GhostMatIfy()
    {
        m_myRenderer.material = m_ghostMat;
    }

    public void SetBaseMat()
    {
        m_myRenderer.material = m_baseMat;
    }

    public void ResetPhase(float time)
    {
        m_phaseTime += time;
    }

    public void ResetMass(float time)
    {
        m_massTime += time;
    }

    public Rigidbody GetRigidbody()
    {
        return m_myRigidBody;
    }

    private void ResetMat()
    {
        gameObject.layer = m_playerLayer;
        SetBaseMat();
    }

    private void ResetScale()
    {
        gameObject.transform.localScale = Vector3.one;
        m_myRigidBody.mass = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            m_mainCameraRef.BeginShake(m_shakeLength, m_shakeStrength);
        }
    }
}
