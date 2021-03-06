## Game

The `Game` class that is concerned with the games state in the form of a board. The state is stored in the private member `Dictionary<int, string> _board`

**Interface**: `IGame`

### ResetBoard

Resets the board to have no squares selected. This would be called on Game init and at the end of a round.

```c#
void ResetBoard();
```

### SetPosition

Sets the position for the given player, exceptions are thrown for invalid and taken positions.

```c#
void SetPosition(Player player, int position)
```

### GetPositionValue

Gets the value of the given position. The default value of `string.empty` is returned if nothing is found.

```c#
string GetPositionValue(int position);
```

### GetCurrentBoard

Returns the current board.

```c#
Dictionary<int, string> GetCurrentBoard();
```

### SwapCurrentPlayer

Swaps the current player. Example: X becomes O and vice versa.

```c#
void SwapCurrentPlayer();
```

### GetCurrentPlayer

Returns the current player stored in game state.

```c#
string GetCurrentPlayer();
```