var CountryID=0
$(document).ready(function () {
    ShowCountryMaster();
    $("#btnSave").click(function () {
        InsertUpdateCountryMaster();
        return false;
    });
});

function InsertUpdateCountryMaster()
{
    try {
        $.post("InsertUpdateCountryMaster", {
            CountryID: CountryID,
            CountryCode: $("#txtCountryCode").val(),
            CountryName: $("#txtCountryName").val()
        }function (data) {
            if (data.Message != "")
            {
                alert(data.Message);
                ClearForm();
                ShowCountryMaster();
            }
        });
    } catch (e) {
        alert("Error in InsertUpdateCountryMaster: " + e.message);
    }
}

function ShowCountryMaster() {
    try {
        $.post("ShowCountryMaster", {},
            function (data) {
                if (data.Message != "")
                {
                    alert(data.Message)
                }
                else (data.Grid != "")
                {
                    $("#dvGrid").html(data.Grid);
                }
            });
    }
    catch (e) {
        alert("Error in ShowCountryMaster: " + e.Message);
    }
}

function ClearForm()
{
    CountryID = 0;
    $("#txtCountryCode").val("");
    $("#txtCountryName").val("");
    $("#txtCountryCode").focus();
}

function EditCountryMaster(ID)
{
    try {
        $.post("EditCountryMaster", { CountryID: ID },
            function (data) {
                if (data.Message != "") {
                    alert(data.Message)
                }
                else {
                    CountryID = ID;
                    $("#txtCountryCode").val(data.CountryCode);
                    $("#txtCountryName").val(data.CountryName);
                }
            });
    }
    catch (e) {
        alert("Error in EditCountryMaster: " + e.Message);
    }
}

function DeleteCountryMaster(ID)
{
    try {
        if (confirm("Do you want to delete?")) {
            $.post("DeleteCountryMaster", { CountryID: ID },
                function (data) {
                    if (data.Message != "") {
                        alert(data.Message);
                        ShowCountryMaster();
                    }

                });
        }
    }
    catch (e) {
        alert("Error in DeleteCountryMaster: " + e.Message);
    }
}