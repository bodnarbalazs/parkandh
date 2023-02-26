function info() {
    var x = document.getElementById("infodiv");
    if (x.style.display === "block") {
      x.style.display = "none";
    } else {
      x.style.display = "block";
    }
    console.log("work");
}