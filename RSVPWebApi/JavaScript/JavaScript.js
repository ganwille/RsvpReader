var uri = 'api/books';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            //$('#slider').slider({min : 10});
            });
        
    
});

function formatItem(item) {
    return item;
}

function read() {
    $.getJSON(uri)
        .done(function (data) {
            var value = $("#spinner").spinner("value");
            var minute = 60000;
            $.each(data, function (key, item) {
                // Add a list item for the product.
                setTimeout(function () {
                    $('#book').text(item);
                }, key * (minute/value));
            });
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#book').text('Error: ' + err);
        });
}

function startRead() {
    // obtain input element through DOM

    var file = document.getElementById('file').files[0];
    if (file) {
        getAsText(file);
    }
}

function getAsText(readFile) {

    var reader = new FileReader();

    // Read file into memory as UTF-16
    reader.readAsText(readFile, "UTF-16");

    // Handle progress, success, and errors
    reader.onprogress = updateProgress;
    reader.onload = loaded;
    reader.onerror = errorHandler;
}

function updateProgress(evt) {
    if (evt.lengthComputable) {
        // evt.loaded and evt.total are ProgressEvent properties
        var loaded = (evt.loaded / evt.total);
        if (loaded < 1) {
            // Increase the prog bar length
            // style.width = (loaded * 200) + "px";
        }
    }
}

function loaded(evt) {
    // Obtain the read file data
    var fileString = evt.target.result;
    // Handle UTF-16 file dump
    if (utils.regexp.isChinese(fileString)) {
        //Chinese Characters + Name validation
    }
    else {
        // run other charset test
    }
    // xhr.send(fileString)
}

function errorHandler(evt) {
    if (evt.target.error.name == "NotReadableError") {
        // The file could not be read
    }
}

$(function () {
    $("#spinner").spinner({
        min: 1,
        max: 1000
    });
});