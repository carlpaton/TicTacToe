# TicTacToe
Classic kids game with a board divided into 9 squares placed over 3 rows with 3 squares per row. Each player represents a `O` or `X` on the board. Players take turns to try get 3 in a row vertically, horizontally or diagonally. First person to get 3 in a row wins, if nobody gets 3 in a row and all board squares are populated the game is a draw.

![https://board-games-galore.fandom.com/wiki/Tic-tac-toe](https://vignette.wikia.nocookie.net/board-games-galore/images/4/47/Tictactoe-winning-vector-639732.jpg/revision/latest?cb=20160711013756)

### Game

**Class**: `Game`

### ResetBoard

Resets the board to have no squares selected. This would be called on Game init and at the end of a round.

```c#
void ResetBoard();
```

### SetRandomPosition

Sets a random position on the board for the given player and returns the position it was set at.

```c#
int SetRandomPosition(Player player);
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

