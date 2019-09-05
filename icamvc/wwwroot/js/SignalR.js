var connection = new signalR.HubConnectionBuilder().withUrl("/connection").build();


connection.start().catch(function (err) {
    return console.error(err.toString());
});

//Listens on Update call from server
connection.on("Update", function () {
    document.getElementById("updateButton").click();
});


function UpdateMessage() {
    connection.invoke("SendUpdate").catch(function (err) {
        return console.error(err.toString());
    })
};