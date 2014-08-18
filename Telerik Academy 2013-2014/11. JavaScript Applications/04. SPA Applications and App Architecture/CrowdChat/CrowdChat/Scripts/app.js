/// <reference path="libs/jquery-2.1.1.min.js" />
/// <reference path="libs/require.js" />
/// <reference path="libs/sammy-latest.min.js" />

(function () {
    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1.min',
            sammy: 'libs/sammy-latest.min'
        }
    });

    require(['jquery', 'sammy'], function ($, sammy) {
        var resourceUrl,
            reloadMessages,
            addMessage;

        resourceUrl = 'http://crowd-chat.herokuapp.com/posts';

        var app = sammy('#main-content', function () {
            this.get('#/home', function () {
                $('#main-content').html('');
            });

            this.get('#/all', function () {
                reloadMessages();
            });

            this.get('#/send', function () {
                $('#main-content').html('');
                $('#main-content')
                    .append($('<label />')
                        .attr('for', 'tb-user')
                        .html('User name: '))
                    .append($('<input/ >')
                        .attr('id', 'tb-user')
                        .attr('name', 'tb-user')
                        .attr('type', 'text'))
                    .append($('<br />'))
                    .append($('<label />')
                        .attr('for', 'tb-text')
                        .html('Message text: '))
                    .append($('<input/ >')
                        .attr('id', 'tb-text')
                        .attr('name', 'tb-text')
                        .attr('type', 'text'))
                    .append($('<br />'))
                    .append($('<a />')
                        .attr('href', '#/send/success')
                        .html('Add new message')
                        .on('click', function () {
                            var message;

                            message = {
                                user: $('#tb-user').val(),
                                text: $('#tb-text').val()
                            };

                            addMessage(message);
                        }));
            });

            this.get('#/send/success', function () {
                $('#main-content').html('');
            });
        });

        app.run('#/home');

        reloadMessages = function () {
            return $.ajax({
                url: resourceUrl,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    var message,
                        $messagesList,
                        i,
                        len;

                    $messagesList = $('<ul/>').addClass('messages-list');

                    for (i = 0, len = data.length; i < len; i++) {
                        message = data[i];

                        $('<li />').addClass('message-item')
                                   .append($('<strong /> ')
                                   .html(message.by))
                                   .append($('<span />')
                                   .html(message.text))
                                   .appendTo($messagesList);
                    }

                    $('#main-content').html($messagesList);
                },
                error: function (err) {
                    $('#main-content').html('Error happened: ' + err);
                }
            });
        };

        addMessage = function (data) {
            return $.ajax({
                url: resourceUrl,
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function () {
                    $('#main-content').html('Successfully added message');
                },
                error: function (err) {
                    $('#main-content').html('Error happened: ' + err);
                }
            });
        };
    });
}());