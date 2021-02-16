$(document).ready(function () {

    var loginForm = $("#loginForm");

    loginForm.submit(function (e) {
        e.preventDefault();
             
            var datatopost = loginForm.serialize();
            $.ajax({
                type: "POST",
                url: e.currentTarget.action,
                data: datatopost,
                dataType: "json",
                //contentType: "application/json",
                async: true,
                success: successCallBack,
                error: function (err, type, httpStatus) {
                    //var errobj = JSON.parse(err.responseText);
                    alert("Giriş başarısız");
                }
            });
        
    });
});


function successCallBack(data) {

    if (data.isRedirect == true) {

        window.location.href = data.redirectUrl;
    }
    else {

        ShowNotification(data.responseViewModelList)
    }
};