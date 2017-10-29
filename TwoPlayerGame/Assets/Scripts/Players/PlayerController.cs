using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    [SerializeField] [Range(0.0f, 1000.0f)] private float Speed = 10.0f;
    [SerializeField] private KeyCode m_leftKey = KeyCode.A;
    [SerializeField] private KeyCode m_rightKey = KeyCode.D;
    [SerializeField] private KeyCode m_upKey = KeyCode.W;
    [SerializeField] private KeyCode m_downKey = KeyCode.S;
    [SerializeField] private Material m_ghostMat;


    private Material m_baseMat;
    private Rigidbody m_myRigidBody;
    private int m_playerLayer;
    private Renderer m_myRenderer;
    // Use this for initialization
    void Awake () {
        m_myRigidBody = GetComponent<Rigidbody>();
        m_myRenderer = GetComponent<Renderer>();
        m_playerLayer = LayerMask.NameToLayer("Player");
        gameObject.layer = m_playerLayer;
        m_baseMat = m_myRenderer.material;
    }
	
	// Update is called once per frame
	void Update () {
        if (PauseManager.OnlyOne.Paused()) { StopMoving(); return; }
        float dx = (Input.GetKey(m_leftKey) ? -1.0f : 0.0f) + (Input.GetKey(m_rightKey) ? 1.0f : 0.0f);
        float dz = (Input.GetKey(m_upKey) ? 1.0f : 0.0f) + (Input.GetKey(m_downKey) ? -1.0f : 0.0f);

        m_myRigidBody.AddForce(new Vector3(dx, 0.0f, dz) * Speed);
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

    public void ResetStateAfter(float time)
    {
        StartCoroutine(StateResetCoroutine(time));
    }

    public Rigidbody GetRigidbody()
    {
        return m_myRigidBody;
    }

    private IEnumerator StateResetCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        ResetMyState();
    }

    private void ResetMyState()
    {
        // TODO: OTHER RESETS HERE
        gameObject.layer = m_playerLayer;
        SetBaseMat();
    }
}
