# TicTacToe
Classic kids game with a board divided into 9 squares placed over 3 rows with 3 squares per row. Each player represents a `O` or `X` on the board. Players take turns to try get 3 in a row vertically, horizontally or diagonally. First person to get 3 in a row wins, if nobody gets 3 in a row and all board squares are populated the game is a draw.

![https://board-games-galore.fandom.com/wiki/Tic-tac-toe](https://raw.githubusercontent.com/carlpaton/TicTacToe/master/Data/tictactoe.jpg)

## Artificial Intelligence (AI)

The game has 3 levels

| Level  | Description                                                  |
| ------ | ------------------------------------------------------------ |
| Easy   | The computer will always use Game.SetRandomPosition          |
| Medium | The computer will favor high value squares first, then randomly select from those squares first. High value squares are determined by the number of possible winning lines they can be a part of. They would be 4 for the middle, 3 for the corners and 2 for each outer lying middle. |
| Hard   | The computer will determine if you have a possible winning line and block you, if not revert to medium level flow. |

## Game

[Game Engine](https://github.com/carlpaton/TicTacToe/tree/master/GameEngine)

## Winner Service

[Game Engine Service](https://github.com/carlpaton/TicTacToe/tree/master/GameEngine/Services)