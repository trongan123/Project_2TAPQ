
function functionDistrict(value) {

    $.ajax({
        url: "https://localhost:7126/Account/GetDistrictByID?id=" + value,
        type: "get",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result, status, xhr) {
            var select = document.getElementById('district');
            var i, L = select.options.length - 1;
            for (i = L; i >= 0; i--) {
                select.remove(i);
            }
            $.each(result, function (index, value) {
                // Add options
                $(select).append('<option value=' + value["idDistrict"] + '>' + value["name"] + '</option>');
            });

            // Set selected value


        },
        error: function (xhr, status, error) {
            console.log("ssssssssssss")
        }
    });
}  

function functionWard(value) {

    $.ajax({
        url: "https://localhost:7126/Account/GetWardByID?id=" + value,
        type: "get",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result, status, xhr) {
            var select = document.getElementById('Ward');
            var i, L = select.options.length - 1;
            for (i = L; i >= 0; i--) {
                select.remove(i);
            }
            $.each(result, function (index, value) {
                // Add options
                $(select).append('<option value=' + value["idWard"] + '>' + value["name"] + '</option>');
            });

            // Set selected value


        },
        error: function (xhr, status, error) {
            console.log("ssssssssssss")
        }
    });
}  


$(document).ready(function () {
    functionDistrict("001");

    functionWard("D000000001");
});