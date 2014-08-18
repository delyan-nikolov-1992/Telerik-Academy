/// <reference path="references.js" />

(function () {
    'use strict';

    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1.min',
            sammy: 'libs/sammy-latest.min',
            kendo: 'libs/kendo.web.min'
        }
    });

    require(['jquery', 'sammy', 'kendo'], function ($, sammy, kendo) {
        var resourceUrl = 'http://localhost:3000';

        clearUserData();

        var app = sammy('#main-content', function () {
            this.get('#/home', function () {
                clearMessages();
                $('#main-content').load('../../partials/form.html');
            });

            this.get('#/user', function () {
                clearMessages();
                $('#main-content').load('../../partials/register.html');
            });

            this.get('#/auth', function () {
                clearMessages();
                $('#main-content').load('../../partials/login.html');
            });

            this.get('#/reg', function () {
                var user,
                    username,
                    password,
                    authCode;

                clearMessages();
                username = $('#tb-register-username').val();

                if (username.length >= 6 && username.length <= 40) {
                    password = $('#tb-register-password').val();

                    authCode = CryptoJS.SHA1(username + password).toString();

                    user = {
                        username: username,
                        authCode: authCode
                    };

                    registerUser(user);
                } else {
                    $('#error-messages').html('Username"s length must be between 6 and 40 symbols, inclusive.');
                    $('#main-content').load('../../partials/form.html');
                }
            });

            this.get('#/logIn', function () {
                var user,
                    username,
                    password,
                    authCode;

                clearMessages();
                username = $('#tb-login-username').val();
                password = $('#tb-login-password').val();

                authCode = CryptoJS.SHA1(username + password).toString();

                user = {
                    username: username,
                    authCode: authCode
                };

                logInUser(user);
            });

            this.get('#/post', function () {
                clearMessages();
                $('#main-content').load('../../partials/create-post.html');
            });

            this.get('#/addMsg', function () {
                var message,
                    title,
                    body;

                clearMessages();

                title = $('#tb-title').val();
                body = $('#tb-body').val();

                message = {
                    title: title,
                    body: body
                };

                addMessage(message);
            });

            this.get('#/posts', function () {
                clearMessages();
                selectMenus();
            });

            this.get('#/all', function () {
                clearMessages();
                getMessages(resourceUrl + '/post');
            });

            this.get('#/all/user', function () {
                clearMessages();

                var username = $('#tb-messages-username').val();

                getMessages(resourceUrl + '/post?user=' + username.toLowerCase());
            });

            this.get('#/all/pattern', function () {
                clearMessages();

                var pattern = $('#tb-messages-pattern').val();

                getMessages(resourceUrl + '/post?pattern=' + pattern.toLowerCase());
            });

            this.get('#/all/user&pattern', function () {
                clearMessages();

                var username = $('#tb-messages-username').val(),
                    pattern = $('#tb-messages-pattern').val();

                getMessages(resourceUrl + '/post?pattern=' + pattern.toLowerCase() + '&user=' + username.toLowerCase());
            });

            this.get('#/logOut', function () {
                clearMessages();
                logOutUser();
            });
        });

        app.run('#/home');

        var registerUser = function (data) {
            return $.ajax({
                url: resourceUrl + '/user',
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function () {
                    $('#main-content').load('../../partials/form.html');
                },
                error: function (err) {
                    $('#error-messages').html(err.message);
                }
            });
        };

        var logInUser = function (data) {
            return $.ajax({
                url: resourceUrl + '/auth',
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    saveUserData(data);

                    $('#main-content').load('../../partials/logout.html');
                },
                error: function (err) {
                    $('#error-messages').html(err.message);
                }
            });
        };

        var logOutUser = function () {
            return $.ajax({
                url: resourceUrl + '/user',
                type: 'GET',
                beforeSend: function (xhr) {
                    var sessionKey = localStorage.getItem('sessionKey');

                    xhr.setRequestHeader('X-SessionKey', sessionKey);
                },
                success: function () {
                    clearUserData();

                    $('#main-content').load('../../partials/form.html');
                },
                error: function (err) {
                    $('#error-messages').html(err.message);
                }
            });
        };

        var addMessage = function (data) {
            return $.ajax({
                url: resourceUrl + '/post',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data),
                beforeSend: function (xhr) {
                    var sessionKey = localStorage.getItem('sessionKey');

                    xhr.setRequestHeader('X-SessionKey', sessionKey);
                },
                success: function () {
                    $('#main-content').load('../../partials/logout.html');
                },
                error: function (err) {
                    $('#error-messages').html(err.message);
                }
            });
        };

        var getMessages = function (url) {
            return $.ajax({
                url: url,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    var i,
                        len,
                        contents = [],
                        message;

                    for (i = 0, len = data.length; i < len; i++) {
                        message = data[i];

                        contents.push({
                            title: message.title,
                            message: message.body,
                            postDate: message.postDate,
                            username: message.user.username
                        });
                    }

                    var messagesDataSource = new kendo.data.DataSource({
                        data: contents,
                        pageSize: 5
                    });

                    $('#grid').kendoGrid({
                        dataSource: messagesDataSource,
                        scrollable: false,
                        sortable: true,
                        pageable: {
                            input: true,
                            numeric: true,
                            refresh: true,
                            pageSizes: true,
                            buttonCount: 5
                        },
                        columns: [
                            { field: "title", title: "Title", width: 80 },
                            { field: "message", title: "Message", width: 100 },
                            { field: "postDate", title: "Post date", width: 80 },
                            { field: "username", title: "Username", width: 80 },
                        ]
                    });
                },
                error: function (err) {
                    $('#error-messages').html(err.message);
                }
            });
        };

        function saveUserData(userData) {
            localStorage.setItem('username', userData.username);
            localStorage.setItem('sessionKey', userData.sessionKey);
        }

        function clearUserData() {
            localStorage.removeItem('username');
            localStorage.removeItem('sessionKey');
        }

        function selectMenus() {
            var mainContent = document.getElementById('main-content');

            mainContent.innerHTML +=
                '<div id="menu-form">' +
                '    <label for="tb-messages-username">Username: </label>' +
                '    <input type="text" id="tb-messages-username">' +
                '    <br />' +
                '    <label for="tb-messages-pattern">Pattern: </label>' +
                '    <input type="text" id="tb-messages-pattern">' +
                '    <br />' +
                '    <a href="#/all" id="btn-all-posts" class="button">All posts</a>' +
                '    <a href="#/all/user" id="btn-all-posts-user" class="button">All posts from user</a>' +
                '    <a href="#/all/pattern" id="btn-all-posts-pattern" class="button">All posts with pattern</a>' +
                '    <a href="#/all/user&pattern" id="btn-all-posts-both" class="button">All posts from user and with pattern</a>' +
                '</div>';
        }

        function clearMessages() {
            $('#error-messages').html(' ');
            $('#grid').html(' ');
        }
    });
}());