if (typeof (PSil) == 'undefined')
    PSil = {};


PSil.Common = function () {
    var item = "sdd";
    return {
        AjaxGet: function (dataType, url, inputData, successCallBack, failureCallBack) {
            console.log(item);
            $.ajax({
                type: "GET",
                dataType: dataType,
                url: url,
                data: inputData,
                cache: false,
                success: function (result, textStatus, jqXHR) {
                    debugger;
                    
                    successCallBack(result);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    debugger;
                    
                    failureCallBack(jqXHR);
                }
            });
        }
    }
}();

PSil.Evaluate = function (command,success,error) {
    var cmdRequest = { "command": command };
    //success({ "result": "output", "status": "string.Empty" });
    //error({ "result": "error", "status": "string.Empty" });
    
    PSil.Common.AjaxGet("html", "/Home/PsilEval", cmdRequest, success, error);
};
