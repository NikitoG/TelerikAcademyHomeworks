(function () {
    var canvas = document.getElementById('the-canvas'),
        ctx = canvas.getContext('2d');

    ctx.font = '72px serif';
    ctx.fillText('Press space to begin :)', 200, 350);

    function checkButton(event) {
        var x = getRandomArbitrary(20, canvas.width - 20),
            y = getRandomArbitrary(20, canvas.height - 20),
            xUpdate = 5,
            yUpdate = 5,
            r = 20;

        if (event.keyCode === 32) {
            playPingPong();
        }

        function playPingPong() {

            ctx.clearRect(0, 0, canvas.width, canvas.height);

            checkDirection(x, y);

            x += xUpdate;
            y += yUpdate;
            drawBall(x, y, r);

            requestAnimationFrame(playPingPong);
        }

        function checkDirection(x, y) {
            if (x + xUpdate + r > canvas.width || x + xUpdate - r < 0) {
                xUpdate *= -1;
            }

            if (y + yUpdate + r > canvas.height || y + yUpdate - r < 0) {
                yUpdate *= -1;
            }
        }

        function drawBall(x, y, r) {

            ctx.fillStyle = '#EA3535';
            ctx.beginPath();
            ctx.arc(x, y, r, 0, 2 * Math.PI);
            ctx.closePath();
            ctx.fill();
        }

        function getRandomArbitrary(min, max) {
            return Math.random() * (max - min) + min;
        }
    }

    document.addEventListener("keypress", checkButton, true);

}());