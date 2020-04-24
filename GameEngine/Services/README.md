## WinnerService

Service to check for winners on the current board.

**Interface**: `IWinnerService`

### GetWinner

Checks the given game board to see if there is a winner.

```c#
WinnerModel GetWinner(Dictionary<int, string> board);
```

## GameLogService

Keeps track of the current game log.

**Interface**: `IGameLogService`

### Append

Appends `message` to the log. Returns the new log.

```c#
string Append(string message);
```

### Reset

Resets the current log. Returns the new empty log.

```c#
string Reset();
```