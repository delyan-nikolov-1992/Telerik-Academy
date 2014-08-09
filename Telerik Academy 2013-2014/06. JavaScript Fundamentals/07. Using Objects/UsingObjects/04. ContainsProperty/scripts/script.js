(function () {
    var person = {
        firstName: 'Doncho',
        lastName: 'Minkov',
        toString: function personToString() {
            return this.firstName + ' ' + this.lastName;
        }
    };

    var hasProp = hasProperty(person, 'firstName');

    jsConsole.writeLine("Has property? " + hasProp);
}).call(this);

function hasProperty(obj, prop) {
    var i;

    for (i in obj) {
        if (i === prop) {
            return true;
        }
    }

    return false;
}