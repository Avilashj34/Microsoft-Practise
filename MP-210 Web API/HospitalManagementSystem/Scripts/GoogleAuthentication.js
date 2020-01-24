/// <reference path="jquery-3.3.1.min.js" />



function getAccessToken() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('& ')[0];
            if (accessToken) {
                isUserRegister(accessToken)
            }
        }            
    }
}

function isUserRegister(accessToken) {
    $.ajax({
        url: 'api/Account/UserInfo',
        method: 'GET',
        header: {
            'content-type': 'application/JSON',
            'Authorization': 'bearer ' + accessToken
        },
        success: function (response) {
            if (response.HasRegistered) {
                localStorage.setItem('accessToken'.accessToken);
                localStorage.setItem('userName', response.Email);
                window.location.href = "Data.html"
            }
            else {
                signUpExternalUser(accessToken)
            }
        }
    });
}

function isUserRegister(accessToken) {
    $.ajax({
        url: 'api/Account/RegisterExternal',
        method: 'POST',
        header: {
            'content-type': 'application/JSON',
            'Authorization': 'bearer ' + accessToken
        },
        success: function () {
            window.location.href = "/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=https%3A%2F%2Flocalhost%3A44351%2FLogin.html&state=GerGr5JlYx4t_KpsK57GFSxVueteyBunu02xJTak5m01";

        }
    })
}