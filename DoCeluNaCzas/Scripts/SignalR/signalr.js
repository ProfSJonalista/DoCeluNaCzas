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

function GetDelays(stopId) {
    //var stopId = document.getElementById("txtTemperature").value;
    var res = "";

    delaysProxy.invoke("GetDelays", stopId).done(function (delays) {
        $.each(delays, function () {
            var delay = this;
            
            console.log("Numer linii: " + delay.BusLineName + " Kierunek: " + delay.Headsign + " Wiadomość: " + delay.DelayMessage);
            res = res + "Numer linii: " + delay.BusLineName + " Kierunek: " + delay.Headsign + " Wiadomość: " + delay.DelayMessage + "</br>";
            document.getElementById("res").innerHTML = res;
        });

        

    }).fail(function (error) {
        console.log('Error: ' + error);
    });
}