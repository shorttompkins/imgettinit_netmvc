//THIS IS FOR TESTING PURPOSES ONLY - CAN BE REMOVED:
//***************************************************

define(['app/test_model'], function (tm) {
    var test = function () {
        var newGame = { Title: "Test New Game Inserted Here", ReleaseDate: "11/18/2013", Description: "Here is the description for the game" };
        $.ajax({
            type: "POST",
            url: "/api/game/",
            dataType: "json",
            data: newGame,
            success: function (d) {
                //the webapi method simply returns the (updated) model (with id set)
                console.log(d);
            },
            error: function (xhr, status, error) {
                console.log("Status: " + status + " | Error: " + error);
            }
        }).done(function () {
            console.log("Done!")
        });


        //now test our dependency:
        //-------------------------
        console.log(tm.getTitle());
    };

    return {
        test: test
    };
});

