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
            $('#RoundId').val(data.roundId);
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
    data.append("RoundId", $('#RoundId').val());
    $.ajax({
        data: data,
        type: "POST",
        url : "/vote/uploadTargets",
        cache: false,
        contentType : false,
        processData : false,
        success: function(da){
            $.each(da, function () {
                var d = document.createElement("div");
                $(d).class = "col-xs-4 col-sm-3";
                var i = document.createElement("img");
                $(i).attr("src", "/img/" + this.targetContent);
                $(i).attr("width", "150");

                $(d).append(i);
                $('#target_info').append(d);
            });
        }
    });
});

$('#choice_form_submit').click(function(){
    var data = new FormData($("#choice_form")[0]);
    data.append("RoundId", $('#RoundId').val());
    console.log(data);
    $.ajax({
        data: data,
        type: "POST",
        url : "/vote/createchoice",
        cache: false,
        contentType : false,
        processData : false,
        success: function(data){
            console.log(data);
            var li = document.createElement('li');
            $(li).text(data.choiceContent);
            var lKey = document.createElement('label');
            $(lKey).text(data.choiceValue);
            var lValue = document.createElement('label');
            $(li).append(lKey);
            $(li).append(lValue);
            $('#choice_info').append(li);
        }
    });
});