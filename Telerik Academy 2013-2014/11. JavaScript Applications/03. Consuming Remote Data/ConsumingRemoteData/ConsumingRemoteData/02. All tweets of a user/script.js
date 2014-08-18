/// <reference path='jquery-2.0.2.js' />

window.onload = function () {
    'use strict';

    var $errorMessage,
        $successMessage,
        reloadTweets,
        resourceUrl;

    resourceUrl = 'https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=';
    $successMessage = $('.messages .success');
    $errorMessage = $('.messages .error');

    reloadTweets = function (data) {
        return $.ajax({
            url: resourceUrl + data.name,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                var tweet,
                    $tweetsList,
                    i,
                    len;

                $tweetsList = $('<ul/>').addClass('tweets-list');

                for (i = 0, len = data.tweets.length; i < len; i++) {
                    tweet = data.tweets[i];

                    $('<li />').addClass('tweet-item')
                               .append($('<strong /> ')
                               .html(tweet))
                               .appendTo($tweetsList);
                }

                $('#tweets-container').html($tweetsList);
            },
            error: function (err) {
                $errorMessage.html('Error happened: ' + err)
                             .show()
                             .fadeOut(2000);
            }
        });
    };

    $(function () {
        $('#btn-list-tweets').on('click', function () {
            var user;

            user = {
                name: $('#tb-name').val()
            };

            reloadTweets(user);
        });
    });
};