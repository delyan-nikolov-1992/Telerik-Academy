(function () {
    var persons = [
        {
            firstname: 'Gosho', lastname: 'Petrov', age: 32
        },
        {
            firstname: 'Bay', lastname: 'Ivan', age: 15
        },
        {
            firstname: 'Lili', lastname: 'Ivanova', age: 181
        },
        {
            firstname: 'Stuart', lastname: 'Little', age: 15
        },
        {
            firstname: 'Gosho', lastname: 'Scorsese', age: 71
        },
        {
            firstname: 'Margot', lastname: 'Ivanova', age: 23
        }
    ];

    jsConsole.writeLine("Grouped by firstname:");
    var groupedByFname = group(persons, 'firstname');
    printGroupedPersons(groupedByFname);

    jsConsole.writeLine("\nGrouped by lastname:");
    var groupedByLname = group(persons, 'lastname');
    printGroupedPersons(groupedByLname);

    jsConsole.writeLine("\nGrouped by age:");
    var groupedByAge = group(persons, 'age');
    printGroupedPersons(groupedByAge);
    
}).call(this);

function group(persons, prop) {
    switch (prop) {
        case 'firstname':
            return groupByFirstname(persons);
        case 'lastname':
            return groupByLastname(persons);
        case 'age':
            return groupByAge(persons);
    }
}

function groupByFirstname(persons) {
    var groupedPersons = {},
        indices = [],
        hasIndex,
        i,
        j;

    for (i = 0; i < persons.length; i++) {
        hasIndex = false;

        for (j = 0; j < indices.length; j++) {
            if (indices[j] === persons[i].firstname) {
                hasIndex = true;
                break;
            }
        }

        if (!hasIndex) {
            var currentPersons = [];
            currentPersons.push(persons[i]);

            for (j = i + 1; j < persons.length; j++) {
                if (persons[i].firstname === persons[j].firstname) {
                    currentPersons.push(persons[j]);
                }
            }

            groupedPersons[persons[i].firstname] = currentPersons;
            indices.push(persons[i].firstname);
        }
    }

    return groupedPersons;
}

function groupByLastname(persons) {
    var groupedPersons = {},
        indices = [],
        hasIndex,
        i,
        j;

    for (i = 0; i < persons.length; i++) {
        hasIndex = false;

        for (j = 0; j < indices.length; j++) {
            if (indices[j] === persons[i].lastname) {
                hasIndex = true;
                break;
            }
        }

        if (!hasIndex) {
            var currentPersons = [];
            currentPersons.push(persons[i]);

            for (j = i + 1; j < persons.length; j++) {
                if (persons[i].lastname === persons[j].lastname) {
                    currentPersons.push(persons[j]);
                }
            }

            groupedPersons[persons[i].lastname] = currentPersons;
            indices.push(persons[i].lastname);
        }
    }

    return groupedPersons;
}

function groupByAge(persons) {
    var groupedPersons = {},
        indices = [],
        hasIndex,
        i,
        j;

    for (i = 0; i < persons.length; i++) {
        hasIndex = false;

        for (j = 0; j < indices.length; j++) {
            if (indices[j] === persons[i].age) {
                hasIndex = true;
                break;
            }
        }

        if (!hasIndex) {
            var currentPersons = [];
            currentPersons.push(persons[i]);

            for (j = i + 1; j < persons.length; j++) {
                if (persons[i].age === persons[j].age) {
                    currentPersons.push(persons[j]);
                }
            }

            groupedPersons[persons[i].age] = currentPersons;
            indices.push(persons[i].age);
        }
    }

    return groupedPersons;
}

function printGroupedPersons(groupedByFname) {
    for (var i in groupedByFname) {
        jsConsole.writeLine(i + ":");

        for (var j = 0; j < groupedByFname[i].length; j++) {
            jsConsole.writeLine(groupedByFname[i][j].firstname + " " + groupedByFname[i][j].lastname +
                    " with age of " + groupedByFname[i][j].age);
        }

        jsConsole.writeLine("");
    }
}