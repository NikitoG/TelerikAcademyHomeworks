(function () {
    var canvas = document.getElementById('the-canvas'),
        ctx = canvas.getContext('2d');

    function drawPerson() {
        // draw face
        var x = 150,
            y = 350,
            r = 100;

        ctx.save();
        ctx.lineWidth = 5;
        ctx.strokeStyle = '#22545F';
        ctx.fillStyle = '#90CAD7';
        ctx.save();
        ctx.beginPath();
        ctx.setTransform(1, 0.1, 0, 1, 0, 0);
        ctx.moveTo(x + r, y);
        ctx.arc(x, y, r, 0, 2 * Math.PI);
        ctx.fill();

        // draw nose
        ctx.moveTo(x - r * 0.2, y + r * 0.2);
        ctx.lineTo(x - r * 0.4, y + r * 0.2);
        ctx.lineTo(x - r * 0.2, y - r * 0.2);
        ctx.stroke();

        // draw mouth
        ctx.moveTo(x - r * 0.2 + r / 2.3, y + r * 0.5);
        ctx.save();
        //ctx.rotate(1 * Math.PI / 180);
        ctx.scale(1, 0.3);
        ctx.arc(x - r * 0.2, (y + r * 0.5) / 0.3, r / 2.3, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.restore();

        // draw eyes
        ctx.moveTo(x - r / 1.8 + r / 5, y - r * 0.2);
        ctx.save();
        ctx.scale(1, 0.5);
        ctx.arc(x - r / 1.8, (y - r * 0.2) / 0.5, r / 5, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.restore();

        ctx.moveTo(x - r / 1.6, y - r * 0.2);
        ctx.beginPath();
        ctx.save();
        ctx.scale(0.2, 0.4);
        ctx.arc((x - r / 1.6) / 0.2, (y - r * 0.2) / 0.4, r / 5, 0, 2 * Math.PI);
        ctx.closePath();
        ctx.fillStyle = '#22545F';
        ctx.fill();
        ctx.restore();

        ctx.moveTo(x + r / 8 + r / 5, y - r * 0.2);
        ctx.save();
        ctx.scale(1, 0.5);
        ctx.arc(x + r / 8, (y - r * 0.2) / 0.5, r / 5, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.restore();

        ctx.moveTo(x + r / 15, y - r * 0.2);
        ctx.beginPath();
        ctx.save();
        ctx.scale(0.3, 0.4);
        ctx.arc((x + r / 15) / 0.3, (y - r * 0.2) / 0.4, r / 5, 0, 2 * Math.PI);
        ctx.closePath();
        ctx.fillStyle = '#22545F';
        ctx.fill();
        ctx.restore();
        ctx.restore();

        //draw a hat
        ctx.lineWidth = 5;
        ctx.strokeStyle = 'black';
        ctx.fillStyle = '#396693';

        ctx.save();
        ctx.beginPath();
        ctx.moveTo(x + r * 1.2, y - 3 * r / 4);
        ctx.setTransform(1, 0, 0, 0.3, 0, 0);
        ctx.arc(x, (y - 3 * r / 4) / 0.3, r * 1.2, 0, 2 * Math.PI);
        ctx.fill();
        ctx.stroke();
        ctx.restore();


        ctx.lineWidth = 5;
        ctx.strokeStyle = 'black';
        ctx.fillStyle = '#396693';
        ctx.beginPath();
        ctx.setTransform(1, 0, 0, 0.6, 0, -60);
        ctx.moveTo(x - r / 1.5, y);
        ctx.lineTo(x - r / 1.5, y + 1.5 * r);
        ctx.arc(x, y + 1.5 * r, r / 1.5, Math.PI, 0, true);
        ctx.lineTo(x + r / 1.5, y);
        ctx.fill();
        ctx.stroke();
        ctx.closePath();
        ctx.beginPath();
        ctx.arc(x, y, r / 1.5, 0, 2 * Math.PI);
        ctx.fill();
        ctx.stroke();
        ctx.restore();
    }

    function drawBike() {
        var i,
            x = 400,
            y = 400,
            r = 80;

        ctx.lineWidth = 3;
        ctx.strokeStyle = '#73A6B3';
        ctx.fillStyle = '#90CAD7';

        // wheels
        ctx.moveTo(x + r, y);
        ctx.beginPath();
        ctx.arc(x, y, r, 0, 2 * Math.PI);
        ctx.fill();
        ctx.stroke();
        ctx.closePath();

        ctx.moveTo(x + 5 * r, y);
        ctx.beginPath();
        ctx.arc(x + 4 * r, y, r, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.closePath();

        drawSpokes(x, y);
        drawSpokes(x + 4 * r, y);

        // frame
        ctx.save();
        ctx.lineWidth = 7;
        ctx.beginPath();
        ctx.moveTo(x, y);
        ctx.lineTo(x + r * 1.8, y);
        ctx.lineTo(x + r * 1.3, y - r * 1.5);
        ctx.closePath();
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + r * 1.8, y);
        ctx.lineTo(x + 3.8 * r, y - r * 1.5);
        ctx.lineTo(x + r * 1.3, y - r * 1.5);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + 4 * r, y);
        ctx.lineTo(x + 3.75 * r, y - r * 2.2);
        ctx.lineTo(x + 3 * r, y - r * 2);
        ctx.moveTo(x + 3.75 * r, y - r * 2.2);
        ctx.lineTo(x + 4.3 * r, y - r * 2.6);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + r * 1.3, y - r * 1.5);
        ctx.lineTo(x + r * 1.15, y - r * 1.9);
        ctx.moveTo(x + r * 0.9, y - r * 1.9);
        ctx.lineTo(x + r * 1.5, y - r * 1.9);
        ctx.stroke();
        ctx.restore();

        ctx.beginPath();
        ctx.moveTo(x + r * 1.8 + 1.5 * 20, y + 1.5 * 20);
        ctx.lineTo(x + r * 1.8 - 1.5 * 20, y - 1.5 * 20);
        ctx.stroke();

        ctx.save();
        ctx.fillStyle = 'white';
        ctx.beginPath();
        ctx.moveTo(x + r * 1.8 + 20, y);
        ctx.arc(x + r * 1.8, y, 20, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.restore();

        function drawSpokes(x, y) {
            ctx.save();
            ctx.lineWidth = 1;
            ctx.beginPath();
            for (i = 0; i < 2 * Math.PI; i += Math.PI / 8) {
                ctx.moveTo(x, y);
                ctx.lineTo(x + r * Math.cos(i), y + r * Math.sin(i));
                ctx.stroke();
            }
            ctx.restore();
        }
    }

    function drawHouse() {
        var x = 900,
            y = 500;

        ctx.lineWidth = 3;
        ctx.strokeStyle = 'black';
        ctx.fillStyle = '#975B5B';

        ctx.beginPath();
        ctx.moveTo(x, y - 200);
        ctx.lineTo(x, y);
        ctx.lineTo(x + 250, y);
        ctx.lineTo(x + 250, y - 200);
        ctx.lineTo(x, y - 200);
        ctx.lineTo(x + 125, y - 325);
        ctx.lineTo(x + 250, y - 200);
        ctx.fill();
        ctx.stroke();

        drawWindow(x + 30, y - 170);
        drawWindow(x + 140, y - 170);
        drawWindow(x + 140, y - 85);

        ctx.beginPath();
        ctx.moveTo(x + 35, y);
        ctx.lineTo(x + 35, y - 75);
        ctx.save();
        ctx.scale(1, 0.6);
        ctx.arc(x + 70, (y - 75) / 0.6, 35, Math.PI, 0, false);
        ctx.restore();
        ctx.lineTo(x + 105, y);
        ctx.moveTo(x + 70, y);
        ctx.lineTo(x + 70, y - 96);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + 65, y - 30);
        ctx.arc(x + 60, y - 30, 5, 0,2 * Math.PI);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + 85, y - 30);
        ctx.arc(x + 80, y - 30, 5, 0,2 * Math.PI);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + 210, y - 220);
        ctx.lineTo(x + 210, y - 300);
        ctx.lineTo(x + 170, y - 300);
        ctx.lineTo(x + 170, y - 220);
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + 210, y - 300);
        ctx.save();
        ctx.scale(1, 0.4);
        ctx.arc(x + 190, (y - 300) / 0.4, 20, 0, 2 * Math.PI);
        ctx.restore();
        ctx.fill();
        ctx.stroke();


        function drawWindow(x, y) {
            ctx.save();
            ctx.strokeStyle = '#975B5B';
            ctx.fillStyle = 'black';

            ctx.beginPath();
            ctx.moveTo(x, y);
            ctx.lineTo(x + 80, y);
            ctx.lineTo(x + 80, y + 50);
            ctx.lineTo(x, y + 50);
            ctx.closePath();
            ctx.fill();
            ctx.stroke();

            ctx.moveTo(x, y + 25);
            ctx.lineTo(x + 80, y + 25);
            ctx.moveTo(x + 40, y);
            ctx.lineTo(x + 40, y + 50);
            ctx.stroke();

            ctx.restore();
        }
    }

    drawPerson();
    drawBike();
    drawHouse();
}());