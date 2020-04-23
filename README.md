# TicTacToe
Classic kids game with a board divided into 9 squares placed over 3 rows with 3 squares per row. Each player represents a `O` or `X` on the board. Players take turns to try get 3 in a row vertically, horizontally or diagonally. First person to get 3 in a row wins, if nobody gets 3 in a row and all board squares are populated the game is a draw.

![https://board-games-galore.fandom.com/wiki/Tic-tac-toe](https://raw.githubusercontent.com/carlpaton/TicTacToe/master/Data/tictactoe.jpg)

## Game

The `Game` class that is concerned with the games state in the form of a board. The state is stored in the private member `Dictionary<int, string> _board`

**Interface**: `IGame`

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

### GetCurrentBoard

Returns the current board.

```c#
Dictionary<int, string> GetCurrentBoard();
```

## WinnerService

Service to check for winners on the current board.

**Interface**: `IWinnerService`

### GetWinner

Checks the given game board to see if there is a winner.

```c#
WinnerModel GetWinner(Dictionary<int, string> board);
```

