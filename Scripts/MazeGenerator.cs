using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] int numberOfPlayers = 1;

    private List<MazeNode> nodes;
    private void Start()
    {
        nodes = new List<MazeNode>();
        GenerateMazeInstant(mazeSize);
        GeneratePlayers();

        //StartCoroutine(GenerateMaze(mazeSize));
    }
   
    void GenerateMazeInstant(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();
        
        //creando nodos

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newnode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newnode);


            }
        }
       

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        //Eligiendo el nodo inicial

        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);


        while (completedNodes.Count < nodes.Count)
        {
            //Comprobando que nodo le sigue al nodo inicial
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            //Comprobar a la derecha del nodo inicial
            if (currentNodeX < size.x - 1)
            {
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) && !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }
            //Comprobar a la izquierda del nodo inicial
            if (currentNodeX > 0)
            {
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) && !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }
            //Comprobando arriba del nodo inicial
            if (currentNodeY < size.y - 1)
            {
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) && !currentPath.Contains(nodes[currentNodeIndex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }
            //Comprobando debajo del nodo inicial
            if (currentNodeY > 0)
            {
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) && !currentPath.Contains(nodes[currentNodeIndex - 1]))
                {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }
            //Comprobando el nodo siguiente
            if (possibleDirections.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);

            }
            else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);
                currentPath[currentPath.Count - 1].SetState(Nodestate.Completed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

        }

        
        IEnumerator GenerateMaze(Vector2Int size)
        {
            List<MazeNode> nodes = new List<MazeNode>();

            //creando nodos

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                    MazeNode newnode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                    nodes.Add(newnode);

                    yield return null;
                }
            }
            List<MazeNode> currentPath = new List<MazeNode>();
            List<MazeNode> completedNodes = new List<MazeNode>();

            //Eligiendo el nodo inicial

            currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
            currentPath[0].SetState(Nodestate.Current);

            while (completedNodes.Count < nodes.Count)
            {
                //Comprobando que nodo le sigue al nodo inicial
                List<int> possibleNextNodes = new List<int>();
                List<int> possibleDirections = new List<int>();

                int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
                int currentNodeX = currentNodeIndex / size.y;
                int currentNodeY = currentNodeIndex % size.y;

                //Comprobar a la derecha del nodo inicial
                if (currentNodeX < size.x - 1)
                {
                    if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) && !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                    {
                        possibleDirections.Add(1);
                        possibleNextNodes.Add(currentNodeIndex + size.y);
                    }
                }
                //Comprobar a la izquierda del nodo inicial
                if (currentNodeX > 0)
                {
                    if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) && !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                    {
                        possibleDirections.Add(2);
                        possibleNextNodes.Add(currentNodeIndex - size.y);
                    }
                }
                //Comprobando arriba del nodo inicial
                if (currentNodeY < size.y - 1)
                {
                    if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) && !currentPath.Contains(nodes[currentNodeIndex + 1]))
                    {
                        possibleDirections.Add(3);
                        possibleNextNodes.Add(currentNodeIndex + 1);
                    }
                }
                //Comprobando debajo del nodo inicial
                if (currentNodeY > 0)
                {
                    if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) && !currentPath.Contains(nodes[currentNodeIndex - 1]))
                    {
                        possibleDirections.Add(4);
                        possibleNextNodes.Add(currentNodeIndex - 1);
                    }
                }
                //Comprobando el nodo siguiente
                if (possibleDirections.Count > 0)
                {
                    int chosenDirection = Random.Range(0, possibleDirections.Count);
                    MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                    switch (possibleDirections[chosenDirection])
                    {
                        case 1:
                            chosenNode.RemoveWall(1);
                            currentPath[currentPath.Count - 1].RemoveWall(0);
                            break;
                        case 2:
                            chosenNode.RemoveWall(0);
                            currentPath[currentPath.Count - 1].RemoveWall(1);
                            break;
                        case 3:
                            chosenNode.RemoveWall(3);
                            currentPath[currentPath.Count - 1].RemoveWall(2);
                            break;
                        case 4:
                            chosenNode.RemoveWall(2);
                            currentPath[currentPath.Count - 1].RemoveWall(3);
                            break;
                    }

                    currentPath.Add(chosenNode);
                    chosenNode.SetState(Nodestate.Current);
                }
                else
                {
                    completedNodes.Add(currentPath[currentPath.Count - 1]);
                    currentPath[currentPath.Count - 1].SetState(Nodestate.Completed);
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

    }
    void GeneratePlayers()
    {
    
        for (int i = 0; i < numberOfPlayers; i++)
        {
               int randomIndex = Random.Range(0, nodes.Count);
                MazeNode randomNode = nodes[randomIndex];
                Vector3 playerPos = randomNode.transform.position;
                Instantiate(playerPrefab, playerPos, Quaternion.identity);
        }
      
    }

}
