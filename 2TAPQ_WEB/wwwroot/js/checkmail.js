function SendOTP() {
    var email = document.getElementById("email");

    if (email.value.trim().length != 0) {

        document.getElementById("emailt").value = email.value;
        $.ajax({

            url: "https://localhost:7126/Account/getOTPcheck?Email=" + email.value,
            type: "get",
            success: function (result, status, xhr) {
                if (result == "") {
                    document.getElementById("send").innerHTML = "Gửi mã thất bại!!"
                } else {
                    document.getElementById("OTP").value = result;
                    document.getElementById("send").innerHTML = "Gửi mã thành công!!"
                }

            },
            error: function (xhr, status, error) {
                console.log("ssssssssssss")
            }
        });
    }
}