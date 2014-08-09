(function test() {
    var persons = [
            {
                name: 'Bagata',
                age: 25
            },
            {
                name: 'Grisho',
                age: 22
            },
            {
                name: 'Kamata',
                age: 50
            }
    ],
        template = document.getElementById("list-item").innerHTML,
        personsList = generateList(persons, template);

    document.write(personsList);
}).call(this);

function generateList(persons, template) {
    var list = '<ul>',
        currentLI;

    template = template.replace(/<strong>/g, '<li><strong>');
    template = template.replace(/<\/span>/g, '</span></li>');

    for (var i in persons) {
        currentLI = template.replace('-{name}-', persons[i].name);
        currentLI = currentLI.replace('-{age}-', persons[i].age);
        list += currentLI;
    }

    list += '</ul>';

    return list;
}