/*document.getElementById("random").addEventListener("click",function(e){
    e.preventDefault();
    sender();
})

document.getElementById("lend").addEventListener("click",function(e){
    e.preventDefault();
    document.querySelector("select").style.display="block";
})

document.querySelector("select").addEventListener("change",function(e){
    const who= e.target.value
    sender(who)
})*/
let user = undefined;
function sender(input){
    const date=document.getElementById("date").value
    fetch("proba.php",{
        method: "POST",
        header:{
            "Content-Type":"application/json"
        },
        body: JSON.stringify([input,date])
    }).then(
        result=>result.json()
    ).then(
        result=>console.log(result)
    )
}
let t = null;
function login() {
    const email=document.getElementById("user").value;
    const pass = document.getElementById("pass").value;
    if (email == "" || pass == "") {
        alert("A bejelentkezési mezők nem lehetnek üresek.")
        return;
    }
    console.log(email);
    console.log(pass);
    fetch("api/getUserByEmail/" + email + "/" + pass)
        .then((response) => response.json())
        .then((data) => {
            console.log(data.id);
            if (data.id==null) {
                alert("Hibás felhasználónév vagy jelszó!")
                location.reload();
                return;
            }
            user = data;
            localStorage.setItem("user", JSON.stringify(user));
            if (user.privateParking != "null") {
                location.replace("/atad2.html")
            } else {
                location.replace("/keres.html")
            }
        });
}
document.onload = () => {
    if (localStorage.getItem("user")!=null) {
        user = localStorage.getItem("user");
        if (user.privateParking!="null") {
            location.replace("/atad2.html")
        } else {
            location.replace("/keres.html")
        }
    }
}