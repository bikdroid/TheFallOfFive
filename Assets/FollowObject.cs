using UnityEngine;


public abstract class FollowObject : MonoBehaviour {
    [SerializeField]public Transform target;
    [SerializeField]private bool autoTargetPlayer = true;


	// Use this for initialization
	virtual protected void Start () {
        if(autoTargetPlayer)
        {
            findTargetPlayer();
        }	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(autoTargetPlayer&&(target==null||!target.gameObject.activeSelf))
        {
            findTargetPlayer();
        }
        if(target!=null&&target.GetComponent<Rigidbody>()!=null &&!target.GetComponent<Rigidbody>().isKinematic)
        {
            follow(Time.deltaTime);
        }	
	}
    protected abstract void follow(float deltaTime);
    public void findTargetPlayer()
    {
        if(target== null)
        {
            GameObject tObj = GameObject.FindGameObjectWithTag("Player");
            if(tObj)
            {
                setTarget(tObj.transform);
            }
        }
    }
    public virtual void setTarget(Transform newTrans)
    {
        target = newTrans;
    }

    public Transform Target { get { return this.target; } }
}
