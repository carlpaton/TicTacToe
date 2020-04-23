## WinnerService

Service to check for winners on the current board.

**Interface**: `IWinnerService`

### GetWinner

Checks the given game board to see if there is a winner.

```c#
WinnerModel GetWinner(Dictionary<int, string> board);
```

