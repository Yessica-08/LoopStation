using UnityEngine;

public class BGControler : MonoBehaviour
{
    [SerializeField] Transform backGroundTransform;

    [SerializeField] float speed;

    [SerializeField] float maxDistanceDisplacement;

    [SerializeField] Vector3 startPosition;

    private void Update()
    {
        MoveBackGround();
    }
    public void MoveBackGround()
    {
        if(backGroundTransform.position.z == maxDistanceDisplacement)
        {
            backGroundTransform.position = startPosition;
        }
        else
        {
            backGroundTransform.position = Vector3.MoveTowards(backGroundTransform.position,new Vector3(0,0,maxDistanceDisplacement), speed * Time.deltaTime);
        }
    }
}
