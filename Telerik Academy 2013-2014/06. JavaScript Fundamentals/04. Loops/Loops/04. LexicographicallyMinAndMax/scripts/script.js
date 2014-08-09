(function () {
    var objects = [document, window, navigator],
        i,
        output,
        properties,
        property,
        id;

    for (i = 0; i < 3; i++) {
        output = "";

        for (property in objects[i]) {
            output += property + " ";
        }

        properties = output.split(" ");
        properties.sort();
        output = "Min: " + properties[1] + "; Max: " + properties[properties.length - 1] + ";";
        jsConsole.writeLine(output);
    }
}).call(this);