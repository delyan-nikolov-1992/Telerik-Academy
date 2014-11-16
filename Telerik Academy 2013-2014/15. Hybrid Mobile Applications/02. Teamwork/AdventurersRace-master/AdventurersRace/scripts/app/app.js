var app = (function (win) {
    'use strict';
    
    // Global error handling
    var showAlert = function (message, title, callback) {
        navigator.notification.alert(message, callback || function () {
        }, title, 'OK');
    };

    var showError = function (message) {
        showAlert(message, 'Error occured');
    };

    win.addEventListener('error', function (e) {
        e.preventDefault();

        var message = e.message + "' from " + e.filename + ":" + e.lineno;

        showAlert(message, 'Error occured');

        return true;
    });

    // Global confirm dialog
    var showConfirm = function (message, title, callback) {
        navigator.notification.confirm(message, callback || function () {
        }, title, ['OK', 'Cancel']);
    };

    var isNullOrEmpty = function (value) {
        return typeof value === 'undefined' || value === null || value === '';
    };

    var isKeySet = function (key) {
        var regEx = /^\$[A-Z_]+\$$/;
        return !isNullOrEmpty(key) && !regEx.test(key);
    };

    var fixViewResize = function () {
        if (device.platform === 'iOS') {
            setTimeout(function () {
                $(document.body).height(window.innerHeight);
            }, 10);
        }
    };

    // Handle device back button tap
    var onBackKeyDown = function (e) {
        e.preventDefault();

        navigator.notification.confirm('Do you really want to exit?', function (confirmed) {
            var exit = function () {
                navigator.app.exitApp();
            };

            if (confirmed === true || confirmed === 1) {
                // Stop EQATEC analytics monitor on app exit
                if (analytics.isAnalytics()) {
                    analytics.Stop();
                }
                AppHelper.logout().then(exit, exit);
            }
        }, 'Exit', ['OK', 'Cancel']);
    };

    function checkConnection() {
        var networkState = navigator.connection.type;

        if (networkState === Connection.NONE) {
            alert('No internet access!');
        }
    }
    
    function onOffline() {
        alert('You have lost internet connection!');
    }
    
    function onOnline() {
        alert('You have already internet access and you can use the full functions of the app!');
    }

    function onBatteryLow(info) {
        alert("Battery Level Low " + info.level + "%");
    }

    var onDeviceReady = function () {
        document.addEventListener("offline", onOffline, false);
        document.addEventListener("online", onOnline, false);
        window.addEventListener("batterylow", onBatteryLow, false);
        document.addEventListener("click", checkConnection, false);

        // Handle "backbutton" event
        document.addEventListener('backbutton', onBackKeyDown, false);

        navigator.splashscreen.hide();
        fixViewResize();

        if (analytics.isAnalytics()) {
            analytics.Start();
        }

        // Initialize AppFeedback
        if (app.isKeySet(appSettings.feedback.apiKey)) {
            try {
                feedback.initialize(appSettings.feedback.apiKey);
            } catch (err) {
                console.log('Something went wrong:');
                console.log(err);
            }
        } else {
            console.log('Telerik AppFeedback API key is not set. You cannot use feedback service.');
        }
    };

    // Handle "deviceready" event
    document.addEventListener('deviceready', onDeviceReady, false);
    // Handle "orientationchange" event
    document.addEventListener('orientationchange', fixViewResize);

    // Initialize Everlive SDK
    var el = new Everlive({
                              apiKey: appSettings.everlive.apiKey,
                              scheme: appSettings.everlive.scheme
                          });

    var emptyGuid = '00000000-0000-0000-0000-000000000000';

    var AppHelper = {

        // Return user profile picture url
        resolveProfilePictureUrl: function (id) {
            if (id && id !== emptyGuid) {
                return el.Files.getDownloadUrl(id);
            } else {
                return 'styles/images/avatar.png';
            }
        },

        // Return current activity picture url
        resolvePictureUrl: function (id) {
            if (id && id !== emptyGuid) {
                return el.Files.getDownloadUrl(id);
            } else {
                return '';
            }
        },

        // Date formatter. Return date in d.m.yyyy format
        formatDate: function (dateString) {
            return kendo.toString(new Date(dateString), 'MMM d, yyyy');
        },

        // Current user logout
        logout: function () {
            return el.Users.logout();
        }
    };

    var os = kendo.support.mobileOS,
        statusBarStyle = os.ios && os.flatVersion >= 700 ? 'black-translucent' : 'black';

    // Initialize KendoUI mobile application
    var mobileApp = new kendo.mobile.Application(document.body, {
                                                     transition: 'slide',
                                                     statusBarStyle: statusBarStyle,
                                                     skin: 'flat'
                                                 });

    var getYear = (function () {
        return new Date().getFullYear();
    }());

    // create an object to store the models for each view
    var models = {
        home: {
            title: 'Welcome to Adventurers Race',
            imageUrl: 'styles/images/HappyTraveler.jpg'
        },
        camera: {
            title: 'Camera'
        },
        users: {
            title: 'All Users',
            ds: new kendo.data.DataSource({
                                              type: 'everlive',
                                              transport: {
                    typeName: 'Users'
                },
                                              schema: {
                    model: {
                                                          id: Everlive.idField
                                                      }
                },
                                              serverSorting: true,
                                              sort: {
                    field: 'Points',
                    dir: 'desc'
                },
                                              serverPaging: true,
                                              page: 1,
                                              pageSize: 10
                                          }),
            alert: function (e) {
                alert("Username: " + e.data.Username + "; Points: " + e.data.Points + ";");
            }
        }
    };

    var listView = kendo.observable({
                                        addImage: function () {
                                            var location = {};

                                            var picSuccess = function (data) {
                                                app.checkLocation.init(location);

                                                var id;
                                                el.Files.create({
                                                                    Filename: Math.random().toString(36).substring(2, 15) + ".jpg",
                                                                    ContentType: "image/jpeg",
                                                                    base64: data
                                                                },
                                                                function (picData) {
                                                                    el.data('Images').create({
                                                                                                 'Image': picData.result.Id,
                                                                                                 'Location': location
                                                                                             },
                                                                                             function (data) {
                                                                                             }, error);
                                                                }, error);
                                            };

                                            var error = function () {
                                                navigator.notification.alert("Unfortunately we could not add the image");
                                            };

                                            var picConfig = {
                                                destinationType: Camera.DestinationType.DATA_URL,
                                                targetHeight: 400,
                                                targetWidth: 400
                                            };

                                            var geoConfig = {
                                                enableHighAccuracy: true
                                            };

                                            var geoSuccess = function (data) {
                                                location = {
                                                    longitude: data.coords.longitude,
                                                    latitude: data.coords.latitude
                                                };

                                                navigator.camera.getPicture(picSuccess, error, picConfig);
                                            };

                                            navigator.geolocation.getCurrentPosition(geoSuccess, error, geoConfig);
                                        },
                                        username: function() {
                                            var username = app.Users.currentUser.get('data').Username;
                                            
                                            return username;
                                        },
                                        points: function() {
                                            var points = app.Users.currentUser.get('data').Points;
                                            
                                            return points;
                                        }

                                    });

    return {
        showAlert: showAlert,
        showError: showError,
        showConfirm: showConfirm,
        isKeySet: isKeySet,
        mobileApp: mobileApp,
        helper: AppHelper,
        everlive: el,
        getYear: getYear,
        models: models,
        listView: listView
    };
}(window));