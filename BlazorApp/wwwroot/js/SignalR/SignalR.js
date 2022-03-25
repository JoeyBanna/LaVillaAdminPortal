$(()=>{
    let NoticeUrl = `https://psl-app-vm3/HotelAdminAPI/notifyHub`;
    const payconnection = new signalR.HubConnectionBuilder()
        .withUrl(NoticeUrl , {
            skipNegotiation: true,
            transport: signalR.HttpTransportType.WebSockets
        })
        .configureLogging(signalR.LogLevel.Information)
        .withAutomaticReconnect({
            nextRetryDelayInMilliseconds: retryContext => {
                if (retryContext.elapsedMilliseconds < 60000) {
                    // If we've been reconnecting for less than 60 seconds so far,
                    // wait between 0 and 10 seconds before the next reconnect attempt.
                    return Math.random() * 10000;
                } else {
                    // If we've been reconnecting for more than 60 seconds so far, stop reconnecting.
                    return null;
                }
            }
        })
        .build();

    // Start
    payconnection.start()
        .then(function () {
            console.log("connected");

            // Join With UserId.
           JoinBookingCreatedNotificationGroup();
            JoinCheckoutDueNotificationGroup();

        })
        .catch(function (err) {
            console.error(err.toString());
        });

    let JoinBookingCreatedNotificationGroup = () => {
        payconnection.invoke("JoinBookingCreatedNotificationGroup", '00000000-0000-0000-0000-000000000000') //login-user-id
            .then(() => {
                console.log('joined JoinBookingCreatedNotificationGroup with 00000000-0000-0000-0000-000000000000');
            })
            .catch((error) => {
                return console.error(error.toString());
            });
    }

    let JoinCheckoutDueNotificationGroup = () => {
        payconnection.invoke("JoinCheckoutDueNotificationGroup", '00000000-0000-0000-0000-000000000000') //login-user-id
            .then(() => {
                console.log('joined JoinCheckoutDueNotificationGroup with 00000000-0000-0000-0000-000000000000');
            })
            .catch((error) => {
                return console.error(error.toString());
            });
    }


    //BookingCreatedNotify
    
    payconnection.on("BookingCreatedNotify", (message) => {
        console.log("BookingCreatedNotify", { message });
        Command: toastr["info"](message, "Booking Notification")

        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });

    // ----- Connection Management
    payconnection
        .onreconnecting((error) => {
            console.assert("onreconnecting", connection.state === signalR.HubConnectionState.Reconnecting);
            console.log("trying to reconnect now so wait");
            console.log("connection lost totally");
        })


    payconnection
        .onreconnected((connectionId) => {
            console.assert("reconnected", connection.state === signalR.HubConnectionState.Connected);
            console.log(`Connection reestablished. Connected with connectionId "${connectionId}".`);
        })


    payconnection
        .onclose((error) => {
            console.assert("onclose", connection.state === signalR.HubConnectionState.Disconnected);
            console.log(`Connection closed due to error "${error}". Try refreshing this page to restart the connection.`);
        });

});
