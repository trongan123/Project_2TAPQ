
function readed() {
    var a = $("#notify").text();
    if (a > 0) {

        $.ajax({
            url: "https://localhost:7126/Pond/readed",
            contentType: "application/json",
            success: function (result, status, xhr) {
                $("#notify").text(0);
                console.log("success");
            },
            error: function (xhr, status, error) {
                console.log(xhr)
            }
        });
    }

}

function readedcoop() {
    var a = $("#notify").text();
    if (a > 0) {

        $.ajax({
            url: "https://localhost:7126/PondCooperative/readed",
            contentType: "application/json",
            success: function (result, status, xhr) {
                $("#notify").text(0);
                console.log("success");
            },
            error: function (xhr, status, error) {
                console.log(xhr)
            }
        });
    }

}
function readedadmin() {
    var a = $("#notify").text();
    if (a > 0) {

        $.ajax({
            url: "https://localhost:7126/PondAdmin/readed",
            contentType: "application/json",
            success: function (result, status, xhr) {
                $("#notify").text(0);
                console.log("success");
            },
            error: function (xhr, status, error) {
                console.log(xhr)
            }
        });
    }

}