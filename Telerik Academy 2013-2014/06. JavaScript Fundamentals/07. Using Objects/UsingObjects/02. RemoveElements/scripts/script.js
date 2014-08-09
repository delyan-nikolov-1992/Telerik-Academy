(function () {
    var elements = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'],
        elementToRemove = 1;

    Array.prototype.remove = function (element) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] === element) {
                this.splice(i, 1);
            }
        }
    };

    elements.remove(elementToRemove);
    jsConsole.writeLine(elements.join(", "));
}).call(this);