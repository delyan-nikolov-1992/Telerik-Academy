(function () {
    var persons = [
        { 
            firstname : 'Gosho', lastname: 'Petrov', age: 32 
        }, 
        {
            firstname: 'Bay', lastname: 'Ivan', age: 81
        },
        {
            firstname: 'Lili', lastname: 'Ivanova', age: 181
        },
        {
            firstname: 'Stuart', lastname: 'Little', age: 15
        },
        {
            firstname: 'Martin', lastname: 'Scorsese', age: 71
        },
        {
            firstname: 'Margot', lastname: 'Robbie', age: 23
        }
    ];

    var youngest = findYoungest(persons);

    jsConsole.writeLine("The youngest person is " + youngest.firstname + " " + youngest.lastname +
                        " with age of " + youngest.age);
}).call(this);

function findYoungest(persons) {
    var youngestPerson = persons[0],
        i;

    for (i = 1; i < persons.length; i++) {
        if (persons[i].age < youngestPerson.age) {
            youngestPerson = persons[i];
        }
    }

    return youngestPerson;
}