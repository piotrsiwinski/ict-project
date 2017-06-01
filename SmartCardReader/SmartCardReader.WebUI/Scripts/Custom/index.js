console.log("Custom js works");
$(document).ready(onDocumentReady);

function onDocumentReady() {
    $("#UniversityDropdown").change(function() {
        var self = this;
        console.log(self.value);

        $.ajax({
            url: '/api/FacultyModels/' + self.value,
            method: "GET",
            dataType: 'json'
        }).done(function(data) {
            console.log(JSON.stringify(data, null, 2));

            var element = $("#FacultyDropdown");
            element.prop('disabled', '');
            element.empty();
            element.append($("<option></option>").attr("value", '').text('Select Faculty'));

            for (var i = 0; i < data.length; i++) {
                element.append($("<option></option>").attr("value", data[i].Id).text(data[i].Name));
            }

        });
    });
    
    $("#FacultyDropdown").change(function() {
        var self = this;
        console.log(self.value);

        $.ajax({
            url: '/api/MajorBaseModels/' + self.value,
            method: "GET",
            dataType: 'json'
        }).done(function(data) {
            console.log(JSON.stringify(data, null, 2));

            var element = $("#MajorsDropdown");
            element.prop('disabled', '');
            element.empty();
            element.append($("<option></option>").attr("value", '').text('Select Major'));

            for (var i = 0; i < data.length; i++) {
                element.append($("<option></option>").attr("value", data[i].Id).text(data[i].Name));
            }

        });
    });
}