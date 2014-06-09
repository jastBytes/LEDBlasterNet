// drawing active image
var image = new Image();

function resize() {
	draw();
}

function draw() {
	var canvas = document.getElementById('picker');
	var ctx = canvas.getContext('2d');

	ctx.clearRect ( 0 , 0 , $(".colorpicker").width(),$(".colorpicker").height());
	ctx.canvas.width  = $(".colorpicker").width();
	ctx.canvas.height = $(".colorpicker").width();
	ctx.drawImage(image, 0, 0, $(canvas).height(), $(canvas).height()); // draw the image on the canvas
}

$(function(){
    var bCanPreview = true; // can preview

    // create canvas and context objects
    var canvas = document.getElementById('picker');
    var ctx = canvas.getContext('2d');

    image.onload = function () {
			draw();
    }

    // select desired colorwheel
    image.src = 'img/colorwheel.png';

    $('#picker').bind("click touchmove", function(e) { // mouse move handler
        if (bCanPreview) {
            // get coordinates of current position
            var canvasOffset = $(canvas).offset();
            var canvasX = Math.floor(e.pageX - canvasOffset.left);
            var canvasY = Math.floor(e.pageY - canvasOffset.top);

            // get current pixel
            var imageData = ctx.getImageData(canvasX, canvasY, 1, 1);
            var pixel = imageData.data;

            // update preview color
            var pixelColor = "rgb("+pixel[0]+", "+pixel[1]+", "+pixel[2]+")";
            $('.preview').css('backgroundColor', pixelColor);

            // update controls
            $('#rVal').val(pixel[0]);
            $('#gVal').val(pixel[1]);
            $('#bVal').val(pixel[2]);
            $('#rgbVal').val(pixel[0]+','+pixel[1]+','+pixel[2]);

            var dColor = pixel[2] + 256 * pixel[1] + 65536 * pixel[0];
            $('#hexVal').val('#' + ('0000' + dColor.toString(16)).substr(-6));
	    var encHex = 'http://192.168.1.109:4221/ledservice/SetHtmlColor?htmlColor=%23' + ('0000' + dColor.toString(16)).substr(-6);
	    $.get(encHex, null, "json");

        }
    });
	/*
    $('#picker').click(function(e) { // click event handler
        bCanPreview = !bCanPreview;
    });
    $('.preview').click(function(e) { // preview click
        $('.colorpicker').fadeToggle("slow", "linear");
        bCanPreview = true;
    });
	*/
	
});
