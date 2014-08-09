var canvas = document.getElementById('the-canvas'),
    context = canvas.getContext('2d'),
    Rect = (function () {
        function Rect(x, y, width, height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        Rect.prototype = {
            drawRect: function () {
                context.strokeRect(this.x, this.y, this.width, this.height);
            }
        };

        return Rect;
    })(),
    Circle = (function () {
        function Circle(x, y, radius) {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        Circle.prototype = {
            drawCircle: function () {
                context.beginPath();
                context.arc(this.x, this.y, this.radius, 0, 2 * Math.PI, false);
                context.stroke();
            }
        };

        return Circle;
    })(),
    Line = (function () {
        function Line(x1, y1, x2, y2) {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        Line.prototype = {
            drawLine: function () {
                context.beginPath();
                context.moveTo(this.x1, this.y1);
                context.lineTo(this.x2, this.y2);
                context.stroke();
            }
        };

        return Line;
    })();

var rect = new Rect(20, 20, 300, 100),
    circle = new Circle(400, 70, 50),
    line = new Line(50, 200, 400, 200);

rect.drawRect();
circle.drawCircle();
line.drawLine();