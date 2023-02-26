function SubmitParkingReservation() {
    const resId = "";
    const uId = "";
    fetch("postReservationSubmissionWithId/" + resId + "/" + uId)
        .then(r => JSON.parse(r))
        .then(d => {
            getReservationsByUserId();
        });
}

function giveSpot(element){
    var clickedId = element.target.id;
    console.log(clickedId);
    fetch("postReservationSubmissionWithId/" + clickedId + "/" + uId)
    .then(()=>{alert("Sikeresen leadtad a parkolót!");user.coin++;})
}