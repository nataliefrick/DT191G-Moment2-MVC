// Set active menu item.
function SetActive(page) {
    document.getElementById(page).classList.add("active");
    console.log("click " + page);
}

/* Hamburger Menu */
/* Open when someone clicks on the span element */
function openNav() {
    document.getElementById("myNav").style.width = "60%";
}

/* Close when someone clicks on the "x" symbol inside the overlay */
function closeNav() {
    document.getElementById("myNav").style.width = "0%";
}



