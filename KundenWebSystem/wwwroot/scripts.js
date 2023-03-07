let currentCount = 0;

function next(currentCount) {
    let elem = document.getElementById('1');

    switch (currentCount) {
        case 0:
            elem.src = "parachute-ge40ccf0a2_1920.jpg";
            break;
        case 1:
            elem.src = "dive-g6967575e9_1920.jpg";
            break;
        case 2:
            elem.src = "snowboarding-g38a804abf_1920.jpg";
            break;
        case 3:
            elem.src = "mountain-biking-g12facdcf0_1920.jpg";
            break;
    }
}

setInterval(function () {
    currentCount += 1;
    next(currentCount);
    if(currentCount > 3) {
        currentCount = 0;
    }
}, 3000);