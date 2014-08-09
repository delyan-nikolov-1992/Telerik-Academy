var engine = (function () {
    var gameField = new GameField(),
        gameObjects = [],
        intervalId = 0,
        snake = null,
        highscore = null,
        Directions = Object.freeze({
            UP: "up",
            DOWN: "down",
            LEFT: "left",
            RIGHT: "right"
        }),
        ObjectSize = Object.freeze({
            WIDTH: 20,
            HEIGHT: 20
        }),
        deviceMotion = {
            x: 0,
            y: 0
        };

    loadHighscoreTable();

    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    };

    function getRandomePositionX(start, end) {
        return Math.floor((Math.random() * (end - start + 1) + start) / ObjectSize.WIDTH) * ObjectSize.WIDTH;
    }

    function getRandomePositionY(start, end) {
        return Math.floor((Math.random() * (end - start + 1) + start) / ObjectSize.HEIGHT) * ObjectSize.HEIGHT;
    }

    function GameField() {
        this.size = Object.freeze({
            WIDTH: 500,
            HEIGHT: 500
        });

        this.canvas = document.querySelector("#gameField");
        this.canvas.width = this.size.WIDTH;
        this.canvas.height = this.size.HEIGHT;
        this.ctx = this.canvas.getContext("2d");
    }

    GameField.prototype.draw = function () {
        var i = 0;

        this.ctx.clearRect(0, 0, this.size.WIDTH, this.size.HEIGHT);

        for (i = 0; i < gameObjects.length; i++) {
            gameObjects[i].draw();
        }
    };

    function GameObject(positionX, positionY, canBeEaten) {
        this.size = ObjectSize;

        this.position = {
            X: positionX,
            Y: positionY
        };

        this.isDestroyed = false;
        this.canBeEaten = canBeEaten;
    }

    GameObject.prototype.onColision = function () {
        if (this.canBeEaten) {
            this.isDestroyed = true;
        }
    };

    GameObject.prototype.update = function () {
        throw new Error("Not Implemented");
    };

    GameObject.prototype.draw = function () {
        gameField.ctx.fillStyle = this.color;
        gameField.ctx.moveTo(this.position.X, this.position.Y);

        if (this.icon) {
            gameField.ctx.drawImage(this.icon, this.position.X, this.position.Y);
        } else {
            gameField.ctx.fillRect(this.position.X, this.position.Y, ObjectSize.WIDTH, ObjectSize.HEIGHT);
        }
    };

    function Food(x, y) {
        GameObject.call(this, x, y, true);
        this.color = "red";
    }

    Food.inherit(GameObject);

    Food.prototype.update = function () {
        if (this.isDestroyed) {
            this.position.X = getRandomePositionX(0, gameField.size.WIDTH - this.size.WIDTH);
            this.position.Y = getRandomePositionY(0, gameField.size.HEIGHT - this.size.HEIGHT);
            this.isDestroyed = false;
        }
    };

    function SnakeBody(x, y) {
        GameObject.call(this, x, y, false);
        this.color = "lightgreen";
    }

    SnakeBody.inherit(GameObject);

    function Snake(x, y, length, direction) {
        GameObject.call(this, x, y, false);
        this.lives = 3;
        this.length = length;
        this.color = "green";
        this.positionStack = [];
        this.bodyArray = [];
        this.direction = direction;
        this.foodEaten = 0;
        this.totalFood = 0;
    }

    Snake.inherit(GameObject);

    Snake.prototype.update = function () {
        var i = 0,
            position = {
                X: 0,
                Y: 0
            };

        position.X = this.position.X;
        position.Y = this.position.Y;
        this.positionStack.unshift(position);
        this.positionStack.pop();

        switch (this.direction) {
            case "up":
                this.position.Y = this.position.Y - this.size.HEIGHT;
                break;
            case "down":
                this.position.Y += this.size.HEIGHT;
                break;
            case "left":
                this.position.X = this.position.X - this.size.WIDTH;
                break;
            case "right":
                this.position.X += this.size.WIDTH;
                break;
            default:
                throw new Error("Use Directions enumeration!");
        }

        for (i = 0; i < this.length; i++) {
            this.bodyArray[i].position = this.positionStack[i];
        }

        if (this.foodEaten >= 3) {
            this.foodEaten = 0;
            this.grow();
        }
    };

    Snake.prototype.changeDirection = function (direction) {
        this.direction = direction;
    };

    Snake.prototype.onColision = function (colisionObject) {
        if (colisionObject.canBeEaten) {
            this.foodEaten++;
            this.totalFood++;
        } else if (this.lives === 0) {
            endGame();
        } else {
            this.lives--;
            this.reset();
        }
    };

    Snake.prototype.grow = function () {
        var position = {
            X: 0,
            Y: 0
        },
            snakeBody = null;

        position.X = this.bodyArray[this.length - 1].position.X;
        position.Y = this.bodyArray[this.length - 1].position.Y;
        snakeBody = new SnakeBody(position.X, position.Y);
        this.bodyArray.push(snakeBody);
        this.positionStack.push(position);
        this.length++;
    };

    Snake.prototype.reset = function () {
        var i = 0;

        this.direction = Directions.RIGHT;
        this.position.X = (this.length + 2) * ObjectSize.WIDTH;
        this.position.Y = 0;

        for (i = 0; i < this.length; i++) {
            this.bodyArray[i].position.X = this.position.X - ((i + 1) * ObjectSize.WIDTH);
            this.bodyArray[i].position.Y = this.position.Y;
            this.positionStack[i].X = this.bodyArray[i].position.X;
            this.positionStack[i].Y = this.bodyArray[i].position.Y;
        }
    };

    Snake.prototype.draw = function () {
        var i = 0;

        gameField.ctx.fillStyle = this.color;
        gameField.ctx.moveTo(this.position.X, this.position.Y);

        if (this.icon) {
            gameField.ctx.drawImage(this.icon, this.position.X, this.position.Y);
        } else {
            gameField.ctx.fillRect(this.position.X, this.position.Y, ObjectSize.WIDTH, ObjectSize.HEIGHT);
        }

        for (i = 0; i < this.length; i++) {
            gameField.ctx.fillStyle = this.bodyArray[i].color;
            gameField.ctx.moveTo(this.bodyArray[i].position.X, this.bodyArray[i].position.Y);
            gameField.ctx.fillRect(this.bodyArray[i].position.X, this.bodyArray[i].position.Y, ObjectSize.WIDTH, ObjectSize.HEIGHT);
        }

        document.querySelector("#lives").innerHTML = this.lives;
        document.querySelector("#points").innerHTML = this.totalFood;
    };


    Snake.prototype.hasBittenHerSelf = function () {
        var result = false,
            i = 0;
        for (i = 0; i < this.length; i++) {
            if (this.position.X === this.bodyArray[i].position.X && this.position.Y === this.bodyArray[i].position.Y) {
                result = true;
            }
        }
        return result;
    };


    Snake.prototype.isOutOfGameField = function () {
        var result = false;
        if (this.position.X < 0 || this.position.X > gameField.size.WIDTH || this.position.Y < 0 || this.position.Y > gameField.size.HEIGHT) {
            result = true;
        }
        return result;
    };


    function StartGame() {
        var snakeLength = 3,
            numberOfFood = 1,
            food = null,
            snakeBody = null,
            i = 0;

        gameObjects = [];
        clearInterval(intervalId);

        if (snakeLength > ((gameField.size.WIDTH - 100) / ObjectSize.WIDTH) || snakeLength <= 1) {
            snakeLength = 3;
        }

        if (numberOfFood <= 0) {
            numberOfFood = 1;
        }

        snake = new Snake((snakeLength + 1) * ObjectSize.WIDTH, 0, snakeLength - 1, Directions.RIGHT);

        for (i = 1; i < snakeLength; i++) {
            snakeBody = new SnakeBody(snake.position.X - (i * ObjectSize.WIDTH), snake.position.Y);
            snake.bodyArray.push(snakeBody);
            snake.positionStack.push(snakeBody.position);
        }

        gameObjects.push(snake);

        for (i = 0; i < numberOfFood; i++) {
            food = new Food(getRandomePositionX(0, gameField.size.WIDTH - ObjectSize.WIDTH), getRandomePositionY(0, gameField.size.HEIGHT - ObjectSize.HEIGHT));
            gameObjects.push(food);
        }

        document.getElementsByTagName("body")[0].addEventListener("keydown", getKey, false);
        window.addEventListener("devicemotion", handleMotionEvent, true);
        gameField.draw();
        intervalId = setInterval(update, 100);
    }

    function endGame() {
        clearInterval(intervalId);
        setTimeout(afterEndGameEvents, 100);
    }

    function afterEndGameEvents() {
        var minScore = highscore.topFive.pop(),
            highscoreObject = {},
            fontSize = 60;

        gameField.ctx.clearRect(0, 0, gameField.size.WIDTH, gameField.size.HEIGHT);
        gameField.ctx.font = fontSize + "px Arial";
        gameField.ctx.textAlign = 'center';
        gameField.ctx.fillStyle = "green";
        gameField.ctx.fillText("Game Over", gameField.size.WIDTH / 2, gameField.size.HEIGHT / 2);
        if (snake.totalFood > minScore.points) {
            highscoreObject.name = prompt("Congratulations!!! This is awesome result! Please, enter your name:");
            highscoreObject.points = snake.totalFood;
            highscore.topFive.push(highscoreObject);
            highscore.topFive.sort(function (a, b) {
                return b.points - a.points;
            });
            saveHighscoreTable();
            loadHighscoreTable();
        } else {
            highscore.topFive.push(minScore);
        }
    }

    function update() {
        var i = 0;

        for (i = 0; i < gameObjects.length; i++) {
            gameObjects[i].update();
        }

        collisionDetect();
        gameField.draw();
    }

    function collisionDetect() {
        var i = 0;

        if (snake.isOutOfGameField()) {
            snake.onColision(snake);
        }

        if (snake.hasBittenHerSelf()) {
            snake.onColision(snake);
        }

        for (i = 1; i < gameObjects.length; i++) {
            if (collide(snake, gameObjects[i])) {
                snake.onColision(gameObjects[i]);
                gameObjects[i].onColision();
            }
        }
    }

    function collide(snakeObj, obj) {
        result = false;

        if (snakeObj.position.X === obj.position.X && snakeObj.position.Y === obj.position.Y &&
            snakeObj.position.X + ObjectSize.WIDTH === obj.position.X + ObjectSize.WIDTH &&
            snakeObj.position.Y + ObjectSize.HEIGHT === obj.position.Y + ObjectSize.HEIGHT) {
            result = true;
        }
        return result;
    }

    function getKey(evt) {
        switch (evt.keyCode) {
            case 37:
                evt.preventDefault();
                if (snake.changeDirection) {
                    snake.changeDirection(Directions.LEFT);
                }
                break;
            case 38:
                evt.preventDefault();
                if (snake.changeDirection) {
                    snake.changeDirection(Directions.UP);
                }
                break;
            case 39:
                evt.preventDefault();
                if (snake.changeDirection) {
                    snake.changeDirection(Directions.RIGHT);
                }
                break;
            case 40:
                evt.preventDefault();
                if (snake.changeDirection) {
                    snake.changeDirection(Directions.DOWN);
                }
                break;
            default:
        }
    }

    function loadHighscoreTable() {
        var i = 0,
            highscoreHTML = "",
            HtmlTable = document.querySelector("#highscoreTable");

        if (localStorage.snakeHighscore) {
            highscore = JSON.parse(localStorage.snakeHighscore);
        } else {
            highscore = {
                topFive: [{ name: "none", points: 0 },
                    { name: "none", points: 0 },
                    { name: "none", points: 0 },
                    { name: "none", points: 0 },
                    { name: "none", points: 0 }]
            };
            saveHighscoreTable();
        }

        for (i = 0; i < highscore.topFive.length; i++) {
            highscoreHTML += '<tr><td>' + (i + 1) + '</td><td class="textCenter">' + highscore.topFive[i].name + '</td><td class="textRight">' + highscore.topFive[i].points + "</td></tr>";
        }

        HtmlTable.innerHTML = highscoreHTML;
    }

    function saveHighscoreTable() {
        localStorage.snakeHighscore = JSON.stringify(highscore);
    }

    function handleMotionEvent(event) {
        var x = event.accelerationIncludingGravity.x,
            y = event.accelerationIncludingGravity.y,
            deltaX = Math.abs(x - deviceMotion.x),
            deltaY = Math.abs(y - deviceMotion.y);

        if (deltaX > 1 || deltaY > 1) {
            if (deltaX > deltaY) {
                if (x > deviceMotion.x) {
                    snake.changeDirection(Directions.LEFT);
                } else {
                    snake.changeDirection(Directions.RIGHT);
                }
            } else {
                if (y > deviceMotion.y) {
                    snake.changeDirection(Directions.DOWN);
                } else {
                    snake.changeDirection(Directions.UP);
                }
            }
        }
    }

    return {
        StartGame: StartGame
    };
}());

engine.StartGame();