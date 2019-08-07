var delaysProxy;

function Connect() {
    $.getScript('http://docelunaczaswebapi.com/Scripts/jquery.signalR-2.4.0.min.js', function () {
        $.getScript('http://docelunaczaswebapi.com/signalr/hubs', function () {

            var url = 'http://docelunaczaswebapi.com/signalr';
            
            var signalrConnection = $.hubConnection(url, {
                useDefaultPath: false
            });

            delaysProxy = signalrConnection.createHubProxy("DelaysHub");
            
            signalrConnection.start({ withCredentials: false }).done(function () {
                alert("Connected");
            }).fail(function (error) {
                alert("Not connected. Error: " + error);
            });
        });
    });
}

function GetDelays() {
    var stopId = document.getElementById("txtTemperature").value;

    delaysProxy.invoke("GetDelays", stopId).done(function (delays) {
        $.each(delays, function () {
            var delay = this;
            console.log("RouteId = " + delay.RouteId + ", bus line name = " + delay.BusLineName);
        });
    }).fail(function (error) {
        console.log('Error: ' + error);
    });
}