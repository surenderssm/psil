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

PSil.Evaluate = function (command, success, error) {
    var cmdRequest = { "command": command };
    //success({ "result": "output", "status": "string.Empty" });
    //error({ "result": "error", "status": "string.Empty" });

    PSil.Common.AjaxGet("html", "/Home/PsilEval", cmdRequest, success, error);
};

$(document).ready(function () {
    $(document).on("click", "#sampleStatements", function () {
        swal({
            title: "Sample Psil Statements <small></small>!",
            text: '(+ 1 2) => 3 , (* 3 4) => 12 ,(* 5 4 3 2 1) => 120 ,  (bind length 10) (bind breadth 10) (* length breadth) => 100, (bind a 10) (bind b a) (bind a 11) (+ a b) => 21',
            html: true
        });
    });
});