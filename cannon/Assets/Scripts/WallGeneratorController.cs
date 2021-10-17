using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneratorController : MonoBehaviour
{
    public List<GameObject> BrickList = new List<GameObject>();
    public GameObject Brick;
    [Range(1, 100)] public int WallRow;
    [Range(1, 100)] public int WallCol;
    [Range(0.1f, 0.5f)] public float WallPadding;
    [Range(0.7f, 0.99f)] public float WallCapTolerance;

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
            var currentRowPosition = 0f;

            for (var j = ((-WallCol / 2f)) + (_brickWidth / 2f); j < (WallCol / 2f); j++)
            {               
                // Creation
                var brick = Instantiate(Brick);
                BrickList.Add(brick);
                brick.transform.SetParent(transform);
                
                // Calc trans
                var brickWidth = Random.Range(_brickWidth * 0.7f, _brickWidth * 1.3f);                
                var x = WallPadding + brickWidth;
                var y = _brickHeight * i;
                
                brick.transform.position = new Vector3(currentRowPosition, transform.position.y + y, transform.position.z);
                brick.transform.localScale = new Vector3(x, brick.transform.localScale.y, brick.transform.localScale.z);

                currentRowPosition += x;

                if (currentRowPosition >= (WallCol / 2f) * WallCapTolerance)
                {
                    break;
                }
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
