// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#round_form_submit").click(function(){
    var data = new FormData();
    var t = $('#round_form').serializeArray();
    $.each(t, function() {
      data.append(this.name, this.value);
    });
    console.log(data);
    $.ajax({
        data: data,
        type: "POST",
        url : "/vote/createround",
        cache : false,
        contentType : false,
        processData : false,
        success: function(data)
        {
            console.log(data);
            $('#RoundDesc').text(data.roundDesc);
            $('#RoundBeginTime').text(data.roundBeginTime);
            $('#RoundEndTime').text(data.roundEndTime);
        },
        error: function(error){
            alert("error");
        }
    });
});

$('#target_form_submit').click(function(){
    var data = new FormData($("#target_form")[0]);
    $.ajax({
        data: data,
        type: "POST",
        url : "/vote/uploadTargets",
        cache: false,
        contentType : false,
        processData : false,
        success: function(data){
            console.log(data);
        }
    });
});