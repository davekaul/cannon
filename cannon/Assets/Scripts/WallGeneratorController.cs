using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneratorController : MonoBehaviour
{
    public List<GameObject> BrickList = new List<GameObject>();
    public GameObject Brick;
    [Range(1, 100)] public int WallRow;
    [Range(1, 100)] public int WallCol;
    [Range(1, 10)] public int WallPadding;

    private float _brickWidth = 1.05f;
    private float _brickHeight = 0.501f;
   
    private void Start()
    {
        StartCoroutine(BuildWall());
    }

    private IEnumerator BuildWall()
    {      
        for(var i = 0; i < WallRow; i++)
        {
            for (var j = ((-WallCol / 2f)) + (_brickWidth / 2f); j < (WallCol / 2f); j++)
            {
                var x = WallPadding * _brickWidth * j;
                var y = _brickHeight * i;
                
                var brick = Instantiate(Brick);
                BrickList.Add(brick);

                brick.transform.SetParent(transform);
                brick.transform.position = transform.position + new Vector3(x, y, 0f);               
            }
        }

        yield return new WaitForSeconds(1f);

        foreach (var b in BrickList)
        {
            b.GetComponent<Rigidbody>().isKinematic = false;
            b.GetComponent<Rigidbody>().useGravity = true;
        }

    }
}
