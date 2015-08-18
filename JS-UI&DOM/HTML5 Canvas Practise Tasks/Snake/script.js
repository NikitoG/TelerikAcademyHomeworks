(function () {
    var x,
        y,
        i,
        len,
        timeOut,
        image,
        isEat = false,
        isEndOfGame = false,
        hasFood = false,
        xUpdate = 1,
        yUpdate = 0,
        snake = [
            {x: 0, y: 0},
            {x: 1, y: 0},
            {x: 2, y: 0},
            {x: 3, y: 0}
        ],
        score = 0,
        food = ['apple.jpg', 'banana.jpg', 'strawberry.jpg', 'melon.jpg'],
        canvas = document.getElementById('the-canvas'),
        ctx = canvas.getContext('2d');

    ctx.fillStyle = '#EA3535';

    function controlGame(event) {
        if (!event) {
            event = {keyCode: 5};
        }
        switch (event.keyCode) {
            case 32:
                playGame();
                break;
            case 37:
                if(!(xUpdate === 1 && yUpdate === 0)) {
                    xUpdate = -1;
                    yUpdate = 0;
                }
                break;
            case 38:
                if(!(xUpdate === 0 && yUpdate === 1)) {
                    xUpdate = 0;
                    yUpdate = -1;
                }
                break;
            case 39:
                if(!(xUpdate === -1 && yUpdate === 0)) {
                    xUpdate = 1;
                    yUpdate = 0;
                }
                break;
            case 40:
                if(!(xUpdate === 0 && yUpdate === -1)) {
                    xUpdate = 0;
                    yUpdate = 1;
                }
                break;
        }

        function playGame() {
            if(!isEndOfGame) {
                isEat = (snake[snake.length - 1].x === x && snake[snake.length - 1].y === y);

                if (isEat) {
                    hasFood = false;
                    snake.push({
                        x: snake[snake.length - 1].x + xUpdate,
                        y: snake[snake.length - 1].y + yUpdate
                    });
                    score++;
                }

                if (!hasFood) {
                    image  = document.getElementById('source');
                    image.src = food[Math.floor(getRandomArbitrary(0, 4))];
                    x = Math.floor(getRandomArbitrary(0, canvas.width) / 20);
                    y = Math.floor(getRandomArbitrary(0, canvas.height) / 20);
                }

                ctx.save();
                ctx.fillStyle = 'white';
                ctx.fillRect(0, 0, canvas.width, canvas.height);
                ctx.restore();


                drawFood(x, y);
                drawSnake(snake);

                if(!isEndOfGame) {
                    isEndOfGame = snake.some(function(el) {
                        return (el.x === snake[snake.length - 1].x + xUpdate) && (el.y === snake[snake.length - 1].y + yUpdate);
                    })
                }

                snake.push({
                    x: snake[snake.length - 1].x + xUpdate,
                    y: snake[snake.length - 1].y + yUpdate
                });
                snake.shift();

                if(!isEndOfGame) {
                    isEndOfGame = snake[snake.length - 1].x >= canvas.width / 20 || snake[snake.length - 1].x < 0 ||
                        snake[snake.length - 1].y >= canvas.height / 20 || snake[snake.length - 1].y < 0;
                }

                timeOut = 120 / (score / 20 + 1);

                setTimeout(playGame, timeOut);
            } else {
                ctx.save();
                ctx.fillStyle = 'white';
                ctx.fillRect(0, 0, canvas.width, canvas.height);
                ctx.restore();

                ctx.font = '200px consolas';
                ctx.fillText(score, 450, 400);
            }
        }


        function drawSnake(snake) {
            ctx.beginPath();
            for (i = 0, len = snake.length; i < len; i += 1) {
                ctx.fillRect(snake[i].x * 20, snake[i].y * 20, 20, 20);
                ctx.strokeRect(snake[i].x * 20, snake[i].y * 20, 20, 20);
            }
        }

        function drawFood(x, y) {
            ctx.drawImage(image , x * 20, y * 20, 20, 20);
            /*ctx.fillRect(x * 20, y * 20, 20, 20);
            ctx.strokeRect(x * 20, y * 20, 20, 20);*/
            hasFood = true;
        }

        function getRandomArbitrary(min, max) {
            return Math.random() * (max - min) + min;
        }
    }

    window.addEventListener('keydown', controlGame, false);
}());