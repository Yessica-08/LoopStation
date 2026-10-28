using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomizer : MonoBehaviour
{
    public List<Transform> randomPositionFree;

    public List<GameObject> randomObject;

    public List<Transform> randomPositionOcuped;

    public List<Transform> randomPositionBackUp;

    private void Start()
    {
        randomPositionBackUp = new List<Transform>(randomPositionFree);
        Randomizer();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Randomizer();
        }
    }

    public void Randomizer()
    {
        randomPositionOcuped.Clear();
        randomPositionFree.Clear();
        randomPositionFree = new List<Transform>(randomPositionBackUp);

        foreach(var obj in randomObject)
        {
            int ramdonPositon = Random.Range(0, randomPositionFree.Count);
            obj.transform.position = randomPositionFree[ramdonPositon].position;
            randomPositionOcuped.Add(randomPositionFree[ramdonPositon]);
            randomPositionFree.Remove(randomPositionFree[ramdonPositon]);                                                                                           
        }
    }
}
