function onCheckParseAddressBtnClick() {
    var text = jsConsole.read('#tb-address'),
        urlAddress,
        protocol = "",
        server = "",
        resource = "",
        i = 0;

    for (; i < text.length; i++) {
        if (text.substr(i, 3) === "://") {
            i += 3;
            break;
        }

        protocol += text[i];
    }

    for (; i < text.length; i++) {
        if (text[i] === '/') {
            break;
        }

        server += text[i];
    }

    resource = text.substr(i);
    urlAddress = new URLAddress(protocol, server, resource);

    jsConsole.writeLine("protocol: " + urlAddress.protocol);
    jsConsole.writeLine("server: " + urlAddress.server);
    jsConsole.writeLine("resource: " + urlAddress.resource);
}

function URLAddress(protocol, server, resource) {
    this.protocol = protocol;
    this.server = server;
    this.resource = resource;
}