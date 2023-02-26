function info() {
    var x = document.getElementById("infodiv");
    if (x.style.display === "block") {
      x.style.display = "none";
    } else {
      x.style.display = "block";
    }
    console.log("work");
}

document.addEventListener('touchstart', handleTouchStart, false);        
document.addEventListener('touchmove', handleTouchMove, false);

var xDown = null;                                                        
var yDown = null;

function getTouches(evt) {
  return evt.touches ||             // browser API
         evt.originalEvent.touches; // jQuery
}                                                     
                                                                         
function handleTouchStart(evt) {
    const firstTouch = getTouches(evt)[0];                                      
    xDown = firstTouch.clientX;                                      
    yDown = firstTouch.clientY;                                      
};                                                
                                                                         
function handleTouchMove(evt) {
    if ( ! xDown || ! yDown ) {
        return;
    }

    var xUp = evt.touches[0].clientX;                                    
    var yUp = evt.touches[0].clientY;

    var xDiff = xDown - xUp;
    var yDiff = yDown - yUp;
    console.log("x: "+xDiff);
    console.log("y: "+yDiff);
    // Get the screen width
    var screenWidth = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;

    // Check if the swipe is bigger than half of the screen width
    if ( Math.abs( xDiff ) > 12 ) {
        if ( xDiff > 0) {
            console.log(location.href.split("/").pop())
            if(location.href.split("/").pop()  == "drivercarpool.html"){
                location.replace("./reward.html");
            }
            if(location.href.split("/").pop()  == "atad2.html"){
                location.replace("./drivercarpool.html");
            }
            if(location.href.split("/").pop()  == "usersetting.html"){
                location.replace("./atad2.html");
            }
            console.log(xDiff)
        } else {
            if(location.href.split("/").pop()  == "reward.html"){
                location.replace("./drivercarpool.html");
            }
            if(location.href.split("/").pop()  == "drivercarpool.html"){
                location.replace("./atad2.html");
            }
            if(location.href.split("/").pop()  == "atad2.html"){
                location.replace("./usersetting.html");
            }
            // alert("left");
        }                       
    }

    /* reset values */
    xDown = null;
    yDown = null;                                             
};
