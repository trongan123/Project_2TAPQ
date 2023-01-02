
$(document).ready(function () {
    ShowAllProducts();
    function ShowAllProducts() {
        var id = document.getElementById("yearnow").value;
        $.ajax({
            url: "https://localhost:7126/CooperativeRoomCooperative/getPond?year="+id,
            type: "get",

            success: function (result, status, xhr) {
                var earning = document.getElementById('earning').getContext('2d');
                var myChart = new Chart(earning, {
                    type: 'bar',

                    data: {
                        labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                        datasets: [{
                            label: 'Ao',
                            data: result,
                            backgroundColor: [

                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',


                            ],

                        }]
                    },
                    options: {
                        responsive: true
                    }
                });
            },
            error: function (xhr, status, error) {
                console.log("ssssssssssss")
            }
        });

    };
});


function functionPond() {
    ShowAllProducts();
    function ShowAllProducts() {
        var id = document.getElementById("yearnow").value;
        $.ajax({
            url: "https://localhost:7126/CooperativeRoomCooperative/getPond",
            type: "get",

            success: function (result, status, xhr) {
                canvas = document.getElementById('earning1');
                ctx = canvas.getContext('2d');
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                var earning = document.getElementById('earning').getContext('2d');
                var myChart = new Chart(earning, {
                    type: 'bar',

                    data: {
                        labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                        datasets: [{
                            label: 'Ao',
                            data: result,
                            backgroundColor: [

                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',


                            ],

                        }]
                    },
                    options: {
                        responsive: true
                    }
                });
            },
            error: function (xhr, status, error) {
                console.log("ssssssssssss")
            }
        });

    };
}



function functionMember() {


    ShowAllProducts();
    function ShowAllProducts() {
        $.ajax({
            url: "https://localhost:7126/MemberCooperative/getMember",
            type: "get",

            success: function (result, status, xhr) {
                canvas = document.getElementById('earning');
                ctx = canvas.getContext('2d');
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                var earning = document.getElementById('earning1').getContext('2d');
                var myChart = new Chart(earning, {
                    type: 'bar',

                    data: {
                        labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                        datasets: [{
                            label: 'Member',
                            data: result,
                            backgroundColor: [

                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(54, 162, 235, 1)',


                            ],

                        }]
                    },
                    options: {
                        responsive: true
                    }
                });
            },
            error: function (xhr, status, error) {
                console.log("ssssssssssss")
            }
        });

    };
}
