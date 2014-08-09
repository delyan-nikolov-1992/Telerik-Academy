(function () {
    var person = {
        firstName: 'Doncho',
        lastName: 'Minkov',
        toString: function personToString() {
            return this.firstName + ' ' + this.lastName;
        }
    };

    var clonedPerson = clone(person);

    jsConsole.writeLine("Person: " + person.toString());
    jsConsole.writeLine("Cloned person: " + clonedPerson.toString());
}).call(this);

function clone(obj) {
    var copy;

    if (obj === null || "Object" !== typeof obj) {
        return obj;
    }

    if (obj instanceof Array) {
        copy = [];

        for (var i = 0 ; i < obj.length ; i++) {
            copy[i] = clone(obj[i]);
        }

        return copy;
    }

    if (obj instanceof Object) {
        copy = {};

        for (var attr in obj) {
            if (obj.hasOwnProperty(attr)) {
                copy[attr] = clone(obj[attr]);
            }
        }

        return copy;
    }
}