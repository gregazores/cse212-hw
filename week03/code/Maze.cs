/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    // this is the constructor part of the class
    // runs automatically when new Maze object is created
    //It takes a dictionary (mazeMap) as input which is a dictionary property
    // which has a tuple key and a bool value
    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // i'll use a helper function to keep things organized
    private void Move(int directionIndex, int deltaX, int deltaY)
    {
        //TryGetValue is a method used with dictionaries to safely retrieve 
        // a value without throwing an exception if the key doesn't exist.
        // usually throws KeyNotFoundException if this is ommited
        // If the position exists, it stores the result in directions
        // If the position does NOT exist, directions remains null. 
        // the if statement becomes valid and InvalidOperationException("Can't go that way!"); is thrown

        // on the other hand, !directions[directionIndex] checks:
        // directions is an array w/c stores movement options
        // If directions[directionIndex] is false, it means there’s a wall, 
        // and the move is not allowed.
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[directionIndex])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // if the move is valid then we can just increment the current x and y values
        _currX += deltaX;
        _currY += deltaY;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // i'll use a helper function to keep things organized
        // if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[0])
        //     throw new InvalidOperationException("Can't go that way!");

        // _currX -= 1;

        Move(0, -1, 0);
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // i'll use a helper function to keep things organized
        // if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[1])
        //     throw new InvalidOperationException("Can't go that way!");

        // _currX += 1;

        Move(1, 1, 0);
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // i'll use a helper function to keep things organized
        // if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[2])
        //     throw new InvalidOperationException("Can't go that way!");

        // _currY -= 1;

        Move(2, 0, -1);
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // i'll use a helper function to keep things organized
        // if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[3])
        //     throw new InvalidOperationException("Can't go that way!");

        // _currY += 1;

        Move(3, 0, 1);
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}