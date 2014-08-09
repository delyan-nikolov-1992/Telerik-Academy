function solve(input) {
    var modelLength = parseInt(input[0]);
    var models = {};
    var templates = {};
    var templateName = "";
    var templateValue = "";
    var result = "";
    var modelName = "";
    var modelOpened = false;
    var printCode = false;
    var templateDefineName = false;
    var templateDefineValue = false;
    var renderName = "";
    var render = false;

    for (var i = 1; i <= modelLength; i++) {
        var current = input[i].split('-');

        models[current[0]] = current[1].split(';');
        //console.log(current[0] + " " + models[current[0]]);
    }

    var codeLength = parseInt(input[modelLength + 1]);
    //console.log(codeLength);

    for (i = modelLength + 2; i < codeLength + modelLength + 2; i++) {
        //console.log(input[i]);
        //result += input[i];
        var currentLine = input[i];

        for (var j = 0; j < currentLine.length; j++) {
            if (currentLine.substr(j, 2) === "{{") {
                j++;
                printCode = true;
            } else if (printCode) {
                if (currentLine.substr(j, 2) === "}}") {
                    printCode = false;
                    j++;
                    continue;
                }

                result += currentLine[j];
            } else if (currentLine.substr(j, 10) === "<nk-model>") {
                j += 9;
                modelOpened = true;
            } else if (modelOpened) {
                if (currentLine.substr(j, 11) === "</nk-model>") {
                    j += 10;
                    modelOpened = false;
                    //console.log(modelName);
                    result += models[modelName];
                    modelName = "";
                    continue;
                }

                modelName += currentLine[j];
            } else if (currentLine.substr(j, 19) === '<nk-template name="') {
                j += 18;
                templateDefineName = true;
            } else if (templateDefineName) {
                if (currentLine.substr(j, 2) === '">') {
                    j++;
                    templateDefineName = false;
                    templateDefineValue = true;
                    continue;
                }

                templateName += currentLine[j];

            } else if (templateDefineValue) {
                if (currentLine.substr(j, 14) === '</nk-template>') {
                    j += 13;
                    templateValue = templateValue.trim();
                    templates[templateName] = templateValue;


                    templateName = "";
                    templateValue = "";
                    templateDefineValue = false;
                    continue;
                }


                templateValue += currentLine[j];

                if (j === currentLine.length - 1) {
                    templateValue += "\n";
                }


            } else if (currentLine.substr(j, 21) === '<nk-template render="') {
                j += 20;
                render = true;

            } else if (render) {
                if (currentLine.substr(j, 4) === '" />') {
                    j += 3;
                    result += templates[renderName];

                    renderName = "";
                    render = false;
                    continue;
                }

                renderName += currentLine[j];
            } else {
                result += currentLine[j];
            }
        }


        // TODOOOO!!!!!!!!!!!!!!!!!!!!!!

        result += '\n';

    }

    //for (var k in templates) {
    //    console.log(k);
    //    console.log(templates[k]);
    //}

    //console.log(input[7]);

    return result.trim();
}