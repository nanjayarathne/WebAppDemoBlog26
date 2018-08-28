/// <reference path="jquery-1.10.2.min.js" />
$(function(){
    $("#btnSubmit").mouseover(function () {
        $("#btnSubmit").css("backgroundColor",'yellow')
    })
    $("#btnSubmit").mouseout(function () {
        $("#btnSubmit").css("backgroundColor", 'grey')
    })

});