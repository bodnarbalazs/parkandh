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
function login() {
    const email=document.getElementById("user").value;
    const pass = document.getElementById("pass").value;
    console.log(email);
    console.log(pass);
    fetch("api/getUserByEmail/" + email + "/" + pass)
        .then(r => r.json())
        .then(d => {
            console.log(d);
            localStorage.setItem("user", JSON.stringify(d));
            console.log(d.privateParking=='null');
            if(d=="Hibás felhasználónév vagy jelszó."){
                alert("Hibás adatok!")
            }
            else if(d.privateParking=='null'){
                console.log("heeeeyhoooo");
                window.location.replace("/keres.html");
            }else{
                window.location.replace("/atad2.html");
            }
        })
}