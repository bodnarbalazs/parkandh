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
    fetch("api/getReservationsByUserId/"+user.id)
    .then((response) => response.json())
        .then((data) => {
            for (let i = 0; i < data.length; i++) {
                if (data[i].fromDate.split('T')[0]==clickedId) {
                    console.log(data[i].id)
                }
                
            }
        })
}