using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Nodestate
{
    Available,
    Current,
    Completed
}

public class MazeNode : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] MeshRenderer floor;

    public void RemoveWall(int wallToRemove)
    {
        walls[wallToRemove].gameObject.SetActive(false);
    }

    public void SetState(Nodestate state)
    {
        switch (state)
        {
            case Nodestate.Available:
                floor.material.color = Color.white;
                break;
            case Nodestate.Current:
                floor.material.color = Color.yellow;
                break;
            case Nodestate.Completed:
                floor.material.color = Color.black;
                break;
        }
    }
}