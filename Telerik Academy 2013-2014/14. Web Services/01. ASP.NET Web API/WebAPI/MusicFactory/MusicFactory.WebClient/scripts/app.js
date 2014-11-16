(function () {
    'use strict';

    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1.min',
            kendo: 'libs/kendo.web.min'
        }
    });

    require(['jquery', 'kendo'], function ($, kendo) {
        var resourceUrl = 'http://localhost:4986/api';
        //clearMessages();
        getMessages(resourceUrl + 'Albums/GetAlbums');

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
                            Title: message.Title,
                            Year: message.Year,
                            Producer: message.Producer
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
                            { field: "year", title: "Year", width: 100 },
                            { field: "producer", title: "Producer", width: 80 }
                        ]
                    });
                },
                error: function (err) {
                    $('#error-messages').html(err.message);
                }
            });
        };

        function clearMessages() {
            $('#error-messages').html(' ');
            $('#grid').html(' ');
        }
    });
}());