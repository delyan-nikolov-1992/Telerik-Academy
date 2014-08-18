/// <reference path="libs/require.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="libs/jquery-2.0.3.js" />

(function () {

    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3",
            sammy: "libs/sammy-0.7.5.min"
        }
    })

    require(["jquery", "sammy"], function ($, sammy) {
        var resourceUrl = 'http://crowd-chat.herokuapp.com/posts';

        var app = sammy("#main-content", function () {
            this.get("#/home", function () {
                $('#chat-div').remove();
                $('#send-div').remove();
                $('#about-div').remove();
                $('#main-content')
                    .append($('<label />').html('Username')
                            .attr("id", "label-user-name"))
                    .append($('<input /> ')
                            .attr("type", "text")
                            .attr("maxlength", "10")
                            .attr("id", "tb-user-name"));
            });

            this.get("#/chat", function () {
                var userName = $('#tb-user-name').val() || 'Anonymous';
                $('#tb-user-name').remove();
                $('#label-user-name').remove();
                $('#about-div').remove();
                $('#main-content')
                    .append($('<div />')
                            .attr("id", "chat-div"))
                    .append($('<div />')
                            .attr("id", "send-div")
                            .append($('<input /> ')
                                .attr("type", "text")
                                .attr("maxlength", "70")
                                .attr("id", "tb-send"))
                            .append($('<button />')
                                .attr("id", "send-btn")
                                .html("Send")
                                .on('click', function () {
                                    var message = {
                                        user: userName,
                                        text: $('#tb-send').val()
                                    };
                                    sendMessage(message);
                                })));
                reloadChat();
            });

            this.get("#/about", function () {
                $('#chat-div').remove();
                $('#send-div').remove();
                $('#tb-user-name').remove();
                $('#label-user-name').remove();
                $('#main-content')
                    .append($('<div />')
                            .attr("id", "about-div")
                            .html("Thanks to:<br/> jQuery, Sammy and RequireJS."));
            });
        });

        sendMessage = function (data) {
            return $.ajax({
                url: resourceUrl,
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    reloadChat();
                    $('#tb-send').val('');
                },
                error: function (err) {
                    console.log(err);
                }
            });
        };

        reloadChat = function () {
            return $.ajax({
                url: resourceUrl,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    var chatters = data;
                    var chatlist = $('<ul/>').attr("id", "chat-list");
                    for (var i = 0; i < chatters.length; i++) {
                        $('<li />')
                        .append($('<strong/>')
                        .html(chatters[i].by))
                        .append($('<br/>'))
                        .append($('<span/>')
                        .html(chatters[i].text))
                        .appendTo(chatlist);
                    };

                    $('#chat-div').html(chatlist);
                },
                error: function (error) {
                }
            });
        };

        app.run("#/home");
    });
}());