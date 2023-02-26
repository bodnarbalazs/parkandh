function SubmitParkingReservation() {
    const resId = "";
    const uId = "";
    fetch("postReservationSubmissionWithId/" + resId + "/" + uId)
        .then(r => JSON.parse(r))
        .then(d => {

        });
}