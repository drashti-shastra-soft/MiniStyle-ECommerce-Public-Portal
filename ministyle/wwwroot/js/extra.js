// Product Size Options
document.addEventListener("DOMContentLoaded", function () {
    const sizeOptions = document.querySelectorAll(".size-option input");
    sizeOptions.forEach(input => {
        input.addEventListener("change", function () {
            document.querySelectorAll(".size-option").forEach(label => label.classList.remove("selected"));
            if (this.checked) {
                this.parentElement.classList.add("selected");
            }
        });
    });
});