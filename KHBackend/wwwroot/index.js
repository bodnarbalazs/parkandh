window.onload = () => {
    if (localStorage.getItem("user") != null) {
        user = JSON.parse(localStorage.getItem("user"));
        if (user.privateParking != "null") {
            location.replace("/atad2.html")
        } else {
            location.replace("/keres.html")
        }
    }
}
