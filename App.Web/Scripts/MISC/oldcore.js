/* File Created: December 30, 2012 */

var currentGameId = 0;
var detailsTemplate = "";
var currentFilters = "{}";
var currentBoxSize = "large";

function init() {
    detailsTemplate = $('#details_template').html();

    loadGames("/api/GetGames", "{}");

    //main GETTIN button click:
    handleGettinButtonToggle();

    initContainer();
    initGameClick();

    handleFilters();

    $('#feed').on('click', function (e) {
        e.preventDefault();
        var hdata;
        $.getJSON("/api/GetActivityByUser", function (data) {
            hdata = data;
        }).done(function () {
            $.each(hdata, function (i, d) {
                $('#feed_items').append($("#activityTemplate").render(d));
            });
        });

        $('#activity_feed').modal({ opacity: 85, overlayClose: true });
    });
    $('#gamesadmin').on('click', function (e) {
        e.preventDefault();
        $.getJSON("/api/GetActivityByUser", function (data) {
            hdata = data;
        }).done(function () {

        });
    });

    $('#findusersbtn').on('click', function (e) {
        e.preventDefault();
        //find users and populate the dropdown!
        $.ajax({
            url: "/api/FindUsers",
            data: "{ s: '" + $('#usersearch').val() + "' }",
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                $('#user_results').html('Loading...').slideDown();
                var searchResults = "";
                $.each(data, function (i, d) {

                    searchResults += "<p style='margin: 2px;'>";
                    if (d.IsFollowed)
                        searchResults += "<a href='#' class='followed' style='float: right;' rel='" + d.UserId + "'>Friend!</a>";
                    else
                        searchResults += "<a href='#' class='follow' style='float: right;' rel='" + d.UserId + "'>Friend?</a>";
                    searchResults += "<img style='width: 40px; height: 40px; vertical-align: middle;' src='" + d.Avatar + "' /> <b>" + d.Username + "</b></p>";
                });
                $('#user_results').html('<div>' + searchResults + '</div>').children('div').slideDown();
            }
        });
    });

    $(document).on('click', 'a.follow', function (e) {
        //FOLLOW this user:
        var $btn = $(this);
        $.ajax({
            url: "/api/FollowUser",
            data: "{ followid: " + $btn.attr('rel') + " }",
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                $btn.removeClass('follow').addClass('followed').text('Friend!');
            }
        });
    });
    $(document).on({
        click: function (e) {
            //UNFOLLOW this user:
            var $btn = $(this);
            $.ajax({
                url: "/api/UnfollowUser",
                data: "{ followid: " + $btn.attr('rel') + " }",
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    $btn.removeClass('followed').addClass('follow').text('Friend?');
                }
            });
        },
        mouseenter: function () {
            $(this).text('Unfriend?');
        },
        mouseleave: function () {
            $(this).text('Friend!');
        }
    }, 'a.followed');
}

function loadGames(url, params) {
    $.ajax({
        url: url,
        data: params,
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            $('#masterlist li').remove();
            $.each(data, function (i, d) {
                var gcntr = Math.abs(i) + 1;
                var mycind = "";
                if (d.UserConsoleId > 0) {
                    mycind = "<span href='#' class='boxbadge c" + d.UserConsoleId + "'>360</span>";
                }
                var myfrind = "";
                if (d.Friends !== null && d.Friends.length > 0) {
                    $.each(d.Friends, function (i, f) {
                        myfrind += "<span href='#'><img src='" + f.Avatar + "' class='boxfriend c" + f.UserConsoleId + "'/></span>";
                    });
                    myfrind = "<div style='position: absolute; bottom: 5px; left: 5px;'>" + myfrind + "</div>";
                }

                //li below had:  style='position: relative;'   --- breaks core functionality of the details slideDown
                $('#masterlist').append("<li class='item" + gcntr + " game " + currentBoxSize + "'><a href='#' class='game' style='position: relative;' rel='" + d.GameId + "'><img src='/Content/assets/covers/" + d.GameId + ".jpg' class='gamebox " + currentBoxSize + "' />" + mycind + myfrind + "</a></li>");
            });

            initContainer();

            //randomly fade each box in
            $('#masterlist li img').hide();
            $('#masterlist li img').each(function (i, e) {
                var rand = Math.random() * (10 - 1) + 1;
                rand = rand * 10;
                $(this).fadeIn(10 * rand);
            });
        }
    });
}

function handleGettinButtonToggle() {
    $(document).on('mouseenter', 'div.gettin_button', function (e) {
        e.preventDefault();
        if (e.target !== this) {
            return true;
        }
        //slide out the console icons choices:
        var width = $(this).children('div').children('a').length * 28;
        $(this).children('div').show().animate({ width: width });
    });

    $(document).on('click', 'a.getit', function (e) {
        e.preventDefault();

        var $btn = $(this);
        var cid = $btn.attr('class').replace('getit c', '');

        //console.log('{ gameid: ' + $btn.attr('rel') + ', consoleid: ' + cid + ', vendorid: 0 }');
        $.ajax({
            url: '/api/GettinGame',
            data: '{ gameid: ' + $btn.attr('rel') + ', consoleid: ' + cid + ', vendorid: 0 }',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (d) {
                $('#get_success').fadeIn();
                window.setTimeout(function () { $('#get_success').fadeOut(); }, 5000);
            }
            //,
            //error: function (jqXHR, textStatus, errorThrown) {
            //    console.log("error: " + textStatus + " | " + errorThrown);
            //}
        });
    });
}

function initContainer() {
    setupContainerWidth();
    $(window).on('resize', function () { setupContainerWidth(); });
}
function setupContainerWidth() {
    $('#container').width($('body').innerWidth() + 200);
    $('#detailsRow').remove();
    $('#masterlist li a img').removeClass('active').css({ 'opacity': '1.0' });
    $("#masterlist li a img.gamebox:not(.active)").next('span.boxbadge').css({ 'opacity': '1.0' });
}


function initGameClick() {
    $(document).on('click', 'a.game', function (e) {
        e.preventDefault();
        var game = $(this);

        $('#masterlist li a img').removeClass('active').animate({ 'opacity': '1.0' }, 200);
        $("#masterlist li a img.gamebox:not(.active)").next('span.boxbadge').animate({ 'opacity': '1.0' }, 200);

        if ($('#detailsRow').length > 0) {
            $('#detailsRow').attr('id', '#detailsRowOLD').slideUp(function () {
                $(this).remove();
            });
            if (currentGameId !== game.attr('rel'))
                showGameDetails(game);
        } else {
            showGameDetails(game);
        }
    });
}

function showGameDetails(game) {
    var screenWidth = $('body').innerWidth();

    var ownersLeft = game.position().left;
    var ownersWidth = game.width();

    game.children('img.gamebox').addClass('active');
    $("#masterlist li a img.gamebox:not(.active)").animate({ 'opacity': '.25' }, 200);
    $("#masterlist li a img.gamebox:not(.active)").next('span.boxbadge').animate({ 'opacity': '.25' }, 200);

    var perRow = parseInt(screenWidth / ownersWidth, 10) + 1;
    var position = parseInt(ownersLeft / ownersWidth, 10) + 1;
    var totalGames = $('#masterlist li.game').length;

    var insertNearItem = (perRow - position) + 1;
    var first = game.parent('li').attr('class').replace('item', '').replace('game', '').replace(currentBoxSize, '') * 1;
    var second = insertNearItem * 1;

    if (first + second < totalGames)
        insertNearItem = 'li.item' + (first + second);
    else
        insertNearItem = 'li.item' + totalGames;

    if (first + second > totalGames) {
        $(insertNearItem).after('<li id="detailsRow" class="detailsRow" style="width: ' + $('body').innerWidth() + 'px; background: transparent url(\'\/content\/assets\/backgrounds\/' + game.attr('rel') + '.jpg\') no-repeat top left;">' + detailsTemplate + '</li>');
    } else {
        $(insertNearItem).before('<li id="detailsRow" class="detailsRow" style="width: ' + $('body').innerWidth() + 'px; background: transparent url(\'\/content\/assets\/backgrounds\/' + game.attr('rel') + '.jpg\') no-repeat top left;">' + detailsTemplate + '</li>');
    }

    $.getJSON("/api/GetGameDetails?gameid=" + game.attr('rel'), function (data) {
        console.log(data);
        renderGameDetails(data);
    }).done(function () {
        $('#detailsRow div.fixed').fadeIn();
    });

    $('#detailsRow').slideDown();

    currentGameId = game.attr('rel');
}
function renderGameDetails(game) {
    //console.log(game);
    $('#detailsRow div.fixed').html($('#detailsTemplate').render(game));
}


function handleFilters() {
    $('#filter_show, #filter_when, #filter_console, #filter_sort').on('change', function () {
        currentFilters = "{ show: '" + $('#filter_show').val() + "', when: '" + $('#filter_when').val() + "', console: " + $('#filter_console').val() + ", sort: '" + $('#filter_sort').val() + "', s: '" + $("#search").val() + "'}";
        loadGames("/api/GetGamesByFilter", currentFilters);
    });

    var options = {
        callback: function () {
            currentFilters = "{ show: '" + $('#filter_show').val() + "', when: '" + $('#filter_when').val() + "', console: " + $('#filter_console').val() + ", sort: '" + $('#filter_sort').val() + "', s: '" + $("#search").val() + "'}";
            loadGames("/api/GetGamesByFilter", currentFilters);
        },
        wait: 750,
        highlight: true,
        captureLength: 2
    };

    $("#search").typeWatch(options);

    $('#search_clear a').on('click', function (e) {
        e.preventDefault();
        $('#filter_show').val('');
        $('#filter_when').val('');
        $('#filter_console').val('');
        $('#filter_sort').val('');
        $("#search").val('');
        loadGames("/api/GetGames", "{}");
    });

    handleBoxSizeToggle();
}
function handleBoxSizeToggle() {
    $(document).on('change', '#toggle_boxsize', function (e) {
        if ($(this).val() === 'small') {
            $('#masterlist li a img.gamebox').animate({ width: 100, height: 125 }, 400);
            $('#masterlist li').animate({ width: 100, height: 125 }, 400).removeClass('large').removeClass('medium').removeClass('small').addClass('small');
        } else if ($(this).val() === 'medium') {
            $('#masterlist li a img.gamebox').animate({ width: 150, height: 188 }, 400);
            $('#masterlist li').animate({ width: 150, height: 188 }, 400).removeClass('large').removeClass('medium').removeClass('small').addClass('medium');
        } else if ($(this).val() === 'large') {
            $('#masterlist li a img.gamebox').animate({ width: 200, height: 250 }, 400);
            $('#masterlist li').animate({ width: 200, height: 250 }, 400).removeClass('large').removeClass('medium').removeClass('small').addClass('large');
        }
        currentBoxSize = $(this).val();
        setupContainerWidth();
    });
}




/* UTILITIES */
function formatDate(dateo) {
    var odate = new Date(parseInt(dateo.substr(6), 10));

    var ugmt = (odate.getTimezoneOffset() / 60);
    var cgmt = -5;
    var dgmt = ugmt + cgmt;
    odate.setHours(odate.getHours() + dgmt);
    var weekday = new Array("Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday");
    var monthname = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec");

    var format = weekday[odate.getDay()] + ", " + monthname[odate.getMonth()] + " " + odate.getDate() + ", " + odate.getFullYear();

    return format;
}
function formatDateShort(dateo) {
    var odate = new Date(parseInt(dateo.substr(6), 10));

    var ugmt = (odate.getTimezoneOffset() / 60);
    var cgmt = -5;
    var dgmt = ugmt + cgmt;
    odate.setHours(odate.getHours() + dgmt);
    var weekday = new Array("Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday");
    var monthname = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec");

    var format = monthname[odate.getMonth()] + " " + odate.getDate() + ", " + odate.getFullYear();

    return format;
}
function formatTime(dateo) {
    var odate = new Date(parseInt(dateo.substr(6), 10));

    var ugmt = (odate.getTimezoneOffset() / 60);
    var cgmt = -5;
    var dgmt = ugmt + cgmt;

    odate.setHours(odate.getHours() + dgmt);

    var hour = odate.getHours();
    var ext = "am";
    if (hour > 12) { hour -= 12; ext = "pm"; } else if (hour === 12) ext = "pm";
    var newTimeStr = hour + ":" + addZero(odate.getMinutes()) + " " + ext;
    return newTimeStr;
}
function addZero(i) { if (i < 10) { i = "0" + i; } return i; }
function checkIfSelf(uid) {
    console.log(uid + " | " + myuid);
    if (uid === myuid)
        return true;
    else
        return false;
}


$.views.helpers({
    formatDateShort: function (val) {
        return formatDateShort(val);
    },
    formatDate: function (val) {
        return formatDate(val);
    },
    formatTime: function (val) {
        return formatTime(val);
    },
    checkIfSelf: function (uid) {
        return checkIfSelf(uid);
    }
});