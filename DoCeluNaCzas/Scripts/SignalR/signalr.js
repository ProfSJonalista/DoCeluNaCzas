﻿var delaysProxy;
var signalrConnection;
var connectionStarted = false;

function Connect(stopId) {
    $.getScript('http://docelunaczaswebapi.com/Scripts/jquery.signalR-2.4.0.min.js', function () {
        $.getScript('http://docelunaczaswebapi.com/signalr/hubs', function () {

            var url = 'http://docelunaczaswebapi.com/signalr';

            signalrConnection = $.hubConnection(url, {
                useDefaultPath: false
            });

            delaysProxy = signalrConnection.createHubProxy("DelaysHub");

            signalrConnection.start({ withCredentials: false }).done(function () {
                console.log("Connected");

                GetDelays(stopId);
                setInterval(GetDelays, 20000, stopId);
            }).fail(function (error) {
                console.log("Not connected. Error: " + error);
            });
        });
    });
}

function GetDelays(stopId) {

    delaysProxy.invoke("GetDelays", stopId).done(function (delays) {
        var table = document.getElementById("delaysTable");
        table.innerHTML = "";
        table.classList = "table";
        table.style.display = "none";
        //table.style.textAlign = "center";

        var thead = document.createElement("thead");

        var headtr = document.createElement("tr");

        var headth = document.createElement("th");
        headth.classList = "col-md-2";


        var headth2 = document.createElement("th");
        headth2.classList = "col-md-7";

        var headth3 = document.createElement("th");
        headth3.classList = "col-md-3";

        headtr.appendChild(headth);
        headth.innerHTML = "Numer linii";

        headtr.appendChild(headth2);
        headth2.innerHTML = "Kierunek";

        headtr.appendChild(headth3);
        headth3.innerHTML = "Odjazd";

        thead.appendChild(headtr);
        table.appendChild(thead);

        $.each(delays, function () {
            var delay = this;
            var tableBody = document.createElement("tbody");

            // cells creation
            for (var j = 0; j < 1; j++) {
                // table row creation
                var tableRow = document.createElement("tr");
                tableRow.classList = "table-row";

                var count = document.getElementsByClassName("table-row").length;
                tableRow.id = "row" + count;

                for (var i = 0; i < 3; i++) {
                    // create element <td> and text node 
                    //Make text node the contents of <td> element
                    // put <td> at end of the table row
                    var tableDataCell1 = document.createElement("td");
                    tableDataCell1.classList = "table-cell";
                    tableDataCell1.id = "column" + i;

                    var cellText1;

                    if (tableDataCell1.id == "column0") {
                        cellText1 = document.createTextNode(delay.BusLineName);
                    } else if (tableDataCell1.id == "column1") {
                        cellText1 = document.createTextNode(delay.Headsign);
                    } else {
                        cellText1 = document.createTextNode(delay.DelayMessage);
                    }

                    tableDataCell1.appendChild(cellText1);
                    tableRow.appendChild(tableDataCell1);
                }

                //row added to end of table body
                tableBody.appendChild(tableRow);
            }

            // append the <tbody> inside the <table>
            table.appendChild(tableBody);
            table.style.display = "table";
        });

    }).fail(function (error) {
        console.log('Error: ' + error);
    });
}

function ConnectOneDelay() {
    $.getScript('http://docelunaczaswebapi.com/Scripts/jquery.signalR-2.4.0.min.js', function () {
        $.getScript('http://docelunaczaswebapi.com/signalr/hubs', function () {

            var url = 'http://docelunaczaswebapi.com/signalr';

            signalrConnection = $.hubConnection(url, {
                useDefaultPath: false
            });

            signalrConnection.start({ withCredentials: false }).done(function () {
                console.log("Connected");
                connectionStarted = true;
                delaysProxy = signalrConnection.createHubProxy("DelaysHub");
            }).fail(function (error) {
                console.log("Not connected. Error: " + error);
            });
        });
    });
}

function GetOneDelay(idName, stopId, routeId, tripId, arrivalTimeHour, arrivalTimeMinute, initialMessage) {
    GetDelay(idName, stopId, routeId, tripId, arrivalTimeHour, arrivalTimeMinute);
    setInterval(function () {
        GetDelay(idName, stopId, routeId, tripId, arrivalTimeHour, arrivalTimeMinute, initialMessage);
    }, 20000);
}

function GetDelay(idName, stopId, routeId, tripId, arrivalTimeHour, arrivalTimeMinute, initialMessage) {
    if (connectionStarted) {
        delaysProxy.invoke("GetOneDelay", stopId, routeId, tripId, arrivalTimeHour, arrivalTimeMinute).done(
            function (estimatedTime) {
                document.getElementById(idName).innerHTML = initialMessage + estimatedTime;
            }).fail(function (error) {
                console.log(error);
            });
    }
}