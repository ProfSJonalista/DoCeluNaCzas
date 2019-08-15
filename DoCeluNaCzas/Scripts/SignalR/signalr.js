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
            var body = document.getElementsByClassName("routes-table-container")[0];

            // create elements <table> and a <tbody>
            var table = document.getElementsByTagName("table")[0];
            var tableBody = document.getElementsByTagName("tbody")[0];

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