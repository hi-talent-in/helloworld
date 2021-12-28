//to bind state dropdownlist. 

$(document).ready(function () {
    $("#Country").change(function () {
        var CountryId = $(this).val();
        var State = $("#State");
        State.empty();
        var v = "<option value='' disabled selected>---Select State---</option>";
        State.append(v);
        $.get("/Home/GetState", { CountryId:CountryId }, function (data) {
           
            $.each(data, function (i, v1) {
                var s = $('<option>').val(v1.stateId).text(v1.stateName).appendTo(State);
            });
        });
    });

//to bind city dropdownlist.
    $("#State").change(function () {
        var id = $(this).val();
        var City = $("#City");
        City.empty();
        var v = "<option value='' selected disabled>---Select City---</option>";
        City.append(v);
        $.get("/Home/GetCity", { StateId: id }, function (data) {
            $.each(data, function (i, v1) {
                var s = $('<option>').val(v1.cityId).text(v1.cityName).appendTo(City);
            });
        });
    });
});

//Div Show and Hide

$(document).ready(function () {
    $("#divothersession1").click(function () {
        $("#divothersession").toggle(1000);
    });
});