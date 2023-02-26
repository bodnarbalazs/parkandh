function Logout() {
    localStorage.clear();
    alert("Sikeresen kijelentkeztél.");
    location.replace("/index.html");
}