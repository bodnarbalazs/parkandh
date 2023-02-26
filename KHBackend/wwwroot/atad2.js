function SubmitParkingReservation() {
    const resId = "";
    const uId = "";
    fetch("postReservationSubmissionWithId/" + resId + "/" + uId)
        .then(r => JSON.parse(r))
        .then(d => {

        });
}

function giveSpot(element){
    var clickedId = element.target.id;
    console.log(clickedId);
    
}