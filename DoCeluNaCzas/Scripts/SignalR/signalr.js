var delaysProxy;
var isInitializedDelays = false;

function Connect(stopId) {
    $.getScript('http://docelunaczaswebapi.com/Scripts/jquery.signalR-2.4.0.min.js', function () {
        $.getScript('http://docelunaczaswebapi.com/signalr/hubs', function () {

            var url = 'http://docelunaczaswebapi.com/signalr';

            var signalrConnection = $.hubConnection(url, {
                useDefaultPath: false
            });

            delaysProxy = signalrConnection.createHubProxy("DelaysHub");

            signalrConnection.start({ withCredentials: false }).done(function () {
                alert("Connected");
                GetDelays(stopId);
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
        if (isInitializedDelays) {
            return;
        }
        isInitializedDelays = true;

        var body = document.getElementsByClassName("routes-table-container")[0];

        var table = document.createElement("table");
        table.classList = "table";

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
            var numberDelays = delays.length;
            console.log(numberDelays);
            var delay = this;

            // create elements <table> and a <tbody>
            //var table = document.getElementsByTagName("table")[0];
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

                    if (tableDataCell1.id == "column0") {
                        var cellText1 = document.createTextNode(delay.BusLineName);
                    }
                    else if (tableDataCell1.id == "column1") {
                        var cellText1 = document.createTextNode(delay.Headsign);
                    }
                    else {
                        var cellText1 = document.createTextNode(delay.DelayMessage);
                    }

                    console.log("Numer linii: " + delay.BusLineName + " Kierunek: " + delay.Headsign + " Wiadomość: " + delay.DelayMessage);



                    tableDataCell1.appendChild(cellText1);

                    tableRow.appendChild(tableDataCell1);

                }

                //row added to end of table body
                tableBody.appendChild(tableRow);
            }

            // append the <tbody> inside the <table>
            table.appendChild(tableBody);
            // put <table> in the <body>
            body.appendChild(table);
        });


    }).fail(function (error) {
        console.log('Error: ' + error);
    });
}