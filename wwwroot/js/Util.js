let urlAPI = "http://localhost:5000/";

function ajaxRequestApi(url, type, data, token, onResponse) {
    $.ajax({
        type: type,
        url: url,
        //headers: { "Authorization": "Bearer " + token },
        contentType: "application/json; charset=utf-8",
        data: data != null ? type == 'GET' ? data : JSON.stringify(data) : null,
        //dataType: "json",
        success: function (response, textStatus, xhr) {
            if (response.Content != undefined) response = response.Content;
            onResponse(response, xhr.status);
        },
        failure: function (response) {
            console.log("Ocorreu um erro ao carregar a página.");
            error = response;
            alert(response.statusText);
        },
        error: function (response) {
            if (response.status == 200) return onResponse(response);
            if (response.responseJSON != undefined && response.responseJSON.Status == 'NotFound') {
                alert(response.responseJSON.Message);
                return onResponse(response);
            }
            if (response.statusText == "error") alert("Ocorreu um erro ao carregar a página, entre em contato com administração do sistema. (Código: API)");
            else {
                let msg = '';
                if (response.responseJSON != undefined) {
                    msg += response.responseJSON.Message + ": ";
                    if (response.responseJSON.InnerException != null) {
                        msg += response.responseJSON.InnerException.ClassName + "\n";
                        msg += response.responseJSON.InnerException.Message + "\n";
                    }

                    if (response.responseJSON.Content != undefined && response.responseJSON.Content.InnerException != null) {
                        msg += response.responseJSON.Content.InnerException.Message + "\n";
                    }

                    if (response.responseJSON.Content != undefined) {
                        msg += response.responseJSON.Content.Message;
                    }
                }
                if (msg == "") {
                    if (response.responseText != undefined) {
                        msg += response.responseText.toString();
                    }
                }
                alert(`Ocorreu um erro ao carregar a página, entre em contato com administração do sistema. (Código: ${response.statusText})\n${msg}`);
            }
            res = response;
        }
    });
}