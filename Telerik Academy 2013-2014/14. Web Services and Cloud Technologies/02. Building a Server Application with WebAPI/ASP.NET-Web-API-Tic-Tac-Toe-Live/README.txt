Tasks:
1. Finish the GameResult to determine the winner (unit test it well)
2. Create two more services by your choice - it may be some leaderboards, game options, game passwords, etc.
3. Write a client by your choice providing you the Tic Tac Toe game for two players - it may be JavaScript, Console, Mobile, etc.

Solutions:
1. The GameResult to determine the winner is in project TicTacToe.GameLogic and the unit tests are in project TicTacToe.Tests, class GameResultValidatorTest.
2. The first service is AvailableGames() in GamesController with url(http://localhost:33257/api/Games/AvailableGames) 
and header(Authorization: Bearer {access_token}).
   The second service is Get(string userId) in UserInfoController with url(http://localhost:33257/api/UserInfo/Get?userId={userId}) 
and header(Authorization: Bearer {access_token}).
3. The best testing tools are Postman and Fiddler. :)